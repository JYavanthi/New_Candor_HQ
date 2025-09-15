import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { environment } from '@environments/environment.development';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-add-file-pop-up',
  templateUrl: './add-file-pop-up.component.html',
  styleUrl: './add-file-pop-up.component.css'
})
export class AddFilePopUpComponent {
  selectedFiles: any=[new File([], "")];
  itcrid: string | Blob;
  showAttach = false
  private apiurl = environment.apiurl;
  fileCount=[1]
  selectedFilesSave: any;

  constructor(public dialogRef: MatDialogRef<AddFilePopUpComponent>,
    private router: Router,public httpSer: HttpServiceService
    ,@Inject(MAT_DIALOG_DATA) public data: any,private http: HttpClient){
      this.itcrid = this.data.crId.toString()
  }
  onNoClick(){

  }

  onFileSelected(event: any,i:any) {
    this.selectedFiles[i]=event.target.files[0]
    const input = event.target as HTMLInputElement;
    const files = input.files;
    if (files?.length&&files?.length > 0) {
      const file = files[0];
      if (i < this.selectedFiles.length) {
        this.selectedFiles[i] = { file: event.target.files[0], name: file.name };
      }
    }
  }

  addRow(file:any){
    if(!file.name){
      alert("Select Attachment Please.")
      return
    }
    this.selectedFiles.push(new File([], ""))
  }

  removeRow(i:any){
    this.selectedFiles?.splice(i,1)
  }
  close(){
    this.dialogRef.close(this.selectedFiles);
  }

  addFile(): void {
    if (!this.selectedFiles || this.selectedFiles.length === 0) {
      console.error('No files selected.');
      return;
    }

    this.selectedFilesSave = this.selectedFiles.map((m:any)=>{
      return m.file
    })

    const formData = new FormData();
    formData.append('itcrid', this.itcrid);

    for (let i = 0; i < this.selectedFilesSave.length; i++) {
      formData.append('files', this.selectedFilesSave[i], this.selectedFilesSave[i].name);
    }

    const apiUrl = this.apiurl + '/ChangeRequest';

    this.http.post(apiUrl, formData).subscribe(
      (response: any) => {
        // this.dialogRef.close(this.selectedFilesSave);
        http://localhost:4200/executive/15/edit
        this.router.navigate(['/executive/'+this.itcrid+'/edit']);
      },
      (error: any) => {
        alert('Error uploading files')
      }
    );
  }

  showAttachFun(){
    this.showAttach = true
  }
}
