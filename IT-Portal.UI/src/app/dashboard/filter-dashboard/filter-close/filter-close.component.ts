import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import * as jspdf from 'jspdf';
import html2canvas from 'html2canvas';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-filter-close',
  templateUrl: './filter-close.component.html',
  styleUrl: './filter-close.component.css'
})
export class FilterCloseComponent {


  private apiurl = environment.apiurls
  constructor(private route: ActivatedRoute, private http: HttpClient) {

  }

  ngOnInit(): void {
    this.getChangeRequest();
    
    this.route.queryParams.subscribe(params => {
      this.plantId = params['plantId'];
      
      this.filterData();
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
        pdf.save('Completed_table.pdf');
      });
    }
  }
  downloadExcel(): void {
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(document.getElementById('excel-table'));
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');


    XLSX.writeFile(wb, 'Completed_excel.xlsx');
  }


  filteredcompletedData: any[] = [];
 
  plantId: string = '';
  completed: any[] = [];
  getChangeRequest() {
    const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';
    this.http.get<any[]>(apiUrls).subscribe(
      (response) => {
        this.completed = response;
        this.filterData();
      },
      (error) => {
        console.error("GET request failed", error);
      }
    );
  }
 
  filterData() {
    // Filter Draft data based on the received plantId
    this.filteredcompletedData = this.completed.filter(item => item.plantId === this.plantId && item.status === 'Completed');
  }


 

}
