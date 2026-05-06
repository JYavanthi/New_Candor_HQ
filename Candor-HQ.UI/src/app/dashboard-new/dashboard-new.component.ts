import { AfterViewInit, Component } from '@angular/core';
import { Router } from '@angular/router';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-dashboard-new',
  templateUrl: './dashboard-new.component.html',
  styleUrl: './dashboard-new.component.css'
})
export class DashboardNewComponent implements AfterViewInit {

  constructor(private router: Router) { }

  ngAfterViewInit() {
    const ctx = document.getElementById('chart') as HTMLCanvasElement;
    new Chart(ctx, {
      type: 'line',
      data: {
        labels: ['2021', '2022', '2023', '2024', '2025'],
        datasets: [
          {
            label: 'Mobile',
            data: [12, 14, 15, 18, 24],
            borderColor: '#4a7be5',
            tension: 0.4
          }
        ]
      }
    });
  }

  goToNewChange() {
    this.router.navigate(['/new-change']);
  }

  goToNewProject() {
    this.router.navigate(['/projectmanagement'])
  }

}
