import { Component, OnInit } from '@angular/core';
import { LoaderServiceService } from './services/loader-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent  implements OnInit{
  
  title = 'IT_Portal';
  loading:any;

  constructor(private loaderService: LoaderServiceService){}
  ngOnInit(): void {
    this.loaderService.loading$.subscribe(isLoading => {
      this.loading = isLoading;
    });
  }
}
