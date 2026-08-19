import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import * as jspdf from 'jspdf';
import html2canvas from 'html2canvas';
import * as XLSX from 'xlsx';
@Component({
  selector: 'app-filter-implemented',
  templateUrl: './filter-implemented.component.html',
  styleUrl: './filter-implemented.component.css'
})
export class FilterImplementedComponent {

  private apiurl = environment.apiurls
  constructor(private route: ActivatedRoute, private http: HttpClient) {

  }

  ngOnInit(): void {
    this.getChangeRequest();
    this.route.queryParams.subscribe(params => {
      this.plantId = params['plantId'];
      // Filter Draft data based on the received plantId
      this.filterimplementData();
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
        pdf.save('Implemented_table.pdf');
      });
    }
  }
  downloadExcel(): void {
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(document.getElementById('excel-table'));
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');


    XLSX.writeFile(wb, 'Implemented_excel.xlsx');
  }

  filteredimplementData: any[] = [];  
  plantId: string = '';
  Implemented: any[] = [];
  getChangeRequest() {
    const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';
    this.http.get<any[]>(apiUrls).subscribe(
      (response) => {
        this.Implemented = response;
        this.filterimplementData();
      },
      (error) => {
        console.error("GET request failed", error);
      }
    );
  }


  filterimplementData() {
    // Filter Draft data based on the received plantId
    this.filteredimplementData = this.Implemented.filter(item => item.plantId === this.plantId && item.status === 'Implemented');
  }

  


}
