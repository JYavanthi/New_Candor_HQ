import { Component, OnInit } from '@angular/core';
import { LoaderServiceService } from './services/loader-service.service';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  title = 'Candor_HQ';
  loading: any;
  showHeader: boolean = true;

  constructor(private loaderService: LoaderServiceService, private router: Router) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {

        this.showHeader = !event.url.includes('login');
      }
    });
  }

  ngOnInit(): void {
    this.loaderService.loading$.subscribe(isLoading => {
      this.loading = isLoading;
    });

  }
}
