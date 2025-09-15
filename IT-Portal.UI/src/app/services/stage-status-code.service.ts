import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StageStatusCodeService {

  constructor() { }

  
getStageStatusCode(changeRequestData:any) {
  switch (changeRequestData?.stage) {
    case 'Initiated':
      if (changeRequestData?.status === 'Draft') return 0;
      if (changeRequestData?.status === 'Pending Approval') return 1;
      break;
      
    case 'Approval':
      if (changeRequestData?.status === 'Approved level1') return 1;
      if (changeRequestData?.status === 'Approved level2') return 1;
      if (changeRequestData?.status === 'Approved')return 2;
      break;
      
    case 'Implementation':
      if (changeRequestData?.status === 'Implement')return 2;
      break;
      
    case 'Release':

      if (changeRequestData?.status === 'Approved level1')return 2;
      if (changeRequestData?.status === 'Approved level2')return 2;
      if (changeRequestData?.status === 'Approved')return 2;
      if (changeRequestData?.status === 'Released')return 2;
      break;
      
    case 'Closure':
      if (changeRequestData?.status === 'Completed')return 2;
      if (changeRequestData?.status === 'Approved level1')return 2;
      if (changeRequestData?.status === 'Approved level2')return 2;
      break;

    default:
      throw new Error('Unknown stage');
  }
  throw new Error('Unknown status for the given stage');
}

getSrSatus(status:any){
  switch (status) {
    case 'Draft':
      return 0
      break

    case 'Pending Approval':
      return 1
      break


    case 'Hod Approval Pending':
      return 2
      break

    case 'Approved':
      return 3
      break
  }
}
}
