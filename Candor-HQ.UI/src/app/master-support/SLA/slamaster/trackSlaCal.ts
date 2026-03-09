// task-tracker.ts

export class TaskTracker {
    private static workingStartHour = 9; // 9 AM
    private static workingEndHour = 18; // 6 PM
    private static workHoursPerDay = TaskTracker.workingEndHour - TaskTracker.workingStartHour;
  
    private startDate: Date;
    private providedHours: number;
  
    constructor(startDate: Date, providedHours: number) {
      this.startDate = startDate;
      this.providedHours = providedHours;
    }
  
    private addWorkingHoursToDate(startDate: Date, hoursToAdd: number): Date {
      let endDate = new Date(startDate);
      let remainingHours = hoursToAdd;
  
      while (remainingHours > 0) {
        if (!this.isWorkingDay(endDate) || endDate.getHours() < TaskTracker.workingStartHour) {
          endDate.setHours(TaskTracker.workingStartHour, 0, 0, 0);
        }
  
        if (endDate.getHours() >= TaskTracker.workingEndHour) {
          endDate.setDate(endDate.getDate() + 1); // Move to the next working day
          endDate.setHours(TaskTracker.workingStartHour, 0, 0, 0); // Reset to start of the working day
          continue;
        }
  
        const hoursInDay = TaskTracker.workingEndHour - endDate.getHours();
        const hoursToEndOfDay = Math.min(hoursInDay, remainingHours);
  
        remainingHours -= hoursToEndOfDay;
        endDate.setHours(endDate.getHours() + hoursToEndOfDay);
      }
  
      return endDate;
    }
  
    private isWorkingDay(date: Date): boolean {
      const dayOfWeek = date.getDay();
      return dayOfWeek >= 1 && dayOfWeek <= 5; // Monday to Friday
    }
  
    private calculateElapsedWorkingHours(now: Date): number {
      let totalElapsedHours = 0;
      let currentDate = new Date(this.startDate);
  
      while (currentDate < now) {
        if (this.isWorkingDay(currentDate)) {
          const endOfDay = new Date(currentDate);
          endOfDay.setHours(TaskTracker.workingEndHour, 0, 0, 0);
  
          if (endOfDay > now) {
            totalElapsedHours += (now.getTime() - currentDate.getTime()) / (1000 * 60 * 60);
            currentDate = now; // End loop
          } else {
            totalElapsedHours += TaskTracker.workHoursPerDay;
            currentDate = endOfDay;
            currentDate.setDate(currentDate.getDate() + 1); // Move to the next day
            currentDate.setHours(TaskTracker.workingStartHour, 0, 0, 0);
          }
        } else {
          currentDate.setDate(currentDate.getDate() + 1);
          currentDate.setHours(TaskTracker.workingStartHour, 0, 0, 0);
        }
      }
  
      return totalElapsedHours;
    }
  
    public getTaskStatus(): string {
      const now = new Date();
      const endDate = this.addWorkingHoursToDate(this.startDate, this.providedHours);
      const totalWorkingHours = this.providedHours;
      const elapsedWorkingHours = this.calculateElapsedWorkingHours(now);
      const usedPercentage = (elapsedWorkingHours / totalWorkingHours) * 100;
  
      if (now > endDate) {
        return 'R';
      } else if (usedPercentage >= 100) {
        return 'R';
      } else if (usedPercentage > 75) {
        return 'Y';
      } else if (usedPercentage <= 75) {
        return 'G';
      } else {
        return 'S';
      }
    }

    public getEndDateFromCurrent(hoursToAdd: number): Date {
      const currentDate = new Date();
      let endDate = new Date(currentDate);
      let remainingHours = hoursToAdd;
  
      // Adjust the time to the start of the working day if it's outside working hours
      if (!this.isWorkingDay(endDate) || endDate.getHours() < TaskTracker.workingStartHour) {
          endDate.setHours(TaskTracker.workingStartHour, 0, 0, 0);
      }
  
      while (remainingHours > 0) {
          // Check if the current date is a working day
          if (!this.isWorkingDay(endDate)) {
              // Move to the next working day
              endDate.setDate(endDate.getDate() + 1);
              endDate.setHours(TaskTracker.workingStartHour, 0, 0, 0);
              continue;
          }
  
          // Calculate hours remaining in the current working day
          const hoursInDay = TaskTracker.workingEndHour - endDate.getHours();
          const minutesInDay = 60 - endDate.getMinutes();
          const secondsInDay = 60 - endDate.getSeconds();
  
          const hoursToEndOfDay = Math.min(hoursInDay, remainingHours);
          const minutesToEndOfDay = Math.min(minutesInDay, remainingHours * 60 - hoursToEndOfDay * 60);
          const secondsToEndOfDay = Math.min(secondsInDay, remainingHours * 3600 - hoursToEndOfDay * 3600 - minutesToEndOfDay * 60);
  
          // Update endDate by adding the hours, minutes, and seconds to the current date
          endDate.setHours(endDate.getHours() + hoursToEndOfDay);
          endDate.setMinutes(endDate.getMinutes() + minutesToEndOfDay);
          endDate.setSeconds(endDate.getSeconds() + secondsToEndOfDay);
  
          // Decrease the remaining hours
          remainingHours -= hoursToEndOfDay;
  
          if (remainingHours > 0) {
              // Move to the next working day if needed
              endDate.setDate(endDate.getDate() + 1);
              endDate.setHours(TaskTracker.workingStartHour, 0, 0, 0);
          }
      }
  
      return endDate;
  }
  
  
  
  }