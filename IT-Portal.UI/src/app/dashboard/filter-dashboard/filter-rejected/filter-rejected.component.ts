import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';import { environment } from '@environments/environment';
import * as jspdf from 'jspdf';
import html2canvas from 'html2canvas';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-filter-rejected',
  templateUrl: './filter-rejected.component.html',
  styleUrl: './filter-rejected.component.css'
})
export class FilterRejectedComponent {

   private apiurl = environment.apiurls
  filterObject: any;
  viewchangerequest: any;
  constructor(private route: ActivatedRoute, private http: HttpClient) {
   
  }

  ngOnInit(): void {
    this.getChangeRequest();
    // Retrieve plantId from query parameters
    this.route.queryParams.subscribe(params => {
      this.filterObject = params;
      // this.filterData();
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
        pdf.save('SummaryReport_table.pdf');
      });
    }
  }
  downloadExcel(): void {
    const ws: XLSX.WorkSheet = XLSX.utils.table_to_sheet(document.getElementById('excel-table'));
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');


    XLSX.writeFile(wb, 'SummaryReport_excel.xlsx');
  }

  filteredRejectData: any[] = [];
  
  plantId: string = '';
  Rejected: any[] = [];
  getChangeRequest() {
    const apiUrls = this.apiurl + '/ViewChangeRequest/ViewChangerequest';
    this.http.get<any[]>(apiUrls).subscribe(
      (response) => {
        this.viewchangerequest = response;
        this.filterData();
      },
      (error) => {
        console.error("GET request failed", error);
      }
    );
  }
  

  filterData() {
    this.filteredRejectData = this.viewchangerequest.filter((m:any) => {
      return (
          (((this.filterObject.plantId)??true)||((this.filterObject.plantId?.length === 0)??true) || this.filterObject.plantId?.includes(m.plantId)) &&
          (((this.filterObject.Category??true)||((this.filterObject.Category?.length === 0)??true)) || this.filterObject.Category?.includes(m.itcategoryId)) &&
          (((this.filterObject.ClassificationId === '')??true) || (this.filterObject.ClassificationId == null??true) || m.itclassificationId === this.filterObject.ClassificationId) &&
          ((this.filterObject.Priority === ''??true )|| (this.filterObject.Priority == null??true) || m.priorityType === this.filterObject.Priority) &&
          ((this.filterObject.Status === ''??true) || (this.filterObject.Status == null??true) || m.status === this.filterObject.Status) &&
          ((this.filterObject.StartDate === ''??true) || (this.filterObject.StartDate == null??true) || m.crdate.split('T')[0] >= this.filterObject.StartDate) &&
          ((this.filterObject.EndDate === ''??true) || (this.filterObject.EndDate == null??true) || m.crdate.split('T')[0] <= this.filterObject.EndDate) &&
          ((this.filterObject.rfcChangeNumber === ''??true) || (this.filterObject.rfcChangeNumber == null??true) || m.crcode === this.filterObject.rfcChangeNumber)
      );
  });
  }
  


}
