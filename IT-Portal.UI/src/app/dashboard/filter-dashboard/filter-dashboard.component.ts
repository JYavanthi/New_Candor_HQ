import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';

import * as jspdf from 'jspdf';
import html2canvas from 'html2canvas';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-filter-dashboard',
  templateUrl: './filter-dashboard.component.html',
  styleUrl: './filter-dashboard.component.css'
})
export class FilterDashboardComponent implements OnInit {

  private apiurl = environment.apiurls
  constructor(private route: ActivatedRoute, private http: HttpClient) {
   
  }

  ngOnInit(): void {
    this.getChangeRequest();
    // Retrieve plantId from query parameters
    this.route.queryParams.subscribe(params => {
      this.plantId = params['plantId'];
      // Filter Draft data based on the received plantId
      this.filterDraftData();
    });
  }
  selectedOption: string = '';

  onOptionSelected(option: string): void {
    this.selectedOption = option;
  }


  generatePDF() {
    const element = document.getElementById('excel-table') as HTMLElement;

    if (element) {
      html2canvas(element).then((canvas) => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jspdf.jsPDF('p', 'mm', 'a4');
        const imgProps = pdf.getImageProperties(imgData);
        const pdfWidth = pdf.internal.pageSize.getWidth();
        const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;
        pdf.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight);
        pdf.save('Open_table.pdf');
      });
    }
  }

  downloadExcel(): void {
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(document.getElementById('excel-table'));
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');


    XLSX.writeFile(wb, 'Open_excel.xlsx');
  }

 

  filteredopenData: any[] = [];
 
  plantId: string = '';
  Open: any[] = [];
  getChangeRequest() {
    const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';
    this.http.get<any[]>(apiUrls).subscribe(
      (response) => {
        this.Open = response;
        this.filterDraftData();
      },
      (error) => {
        console.error("GET request failed", error);
      }
    );
  }
  
  filterDraftData() {
   
    this.filteredopenData = this.Open.filter(item => item.plantId == this.plantId && item.status !== 'Completed');

    console.log('aaaaa:', this.filteredopenData)
  }
  

   
  }

  
 

