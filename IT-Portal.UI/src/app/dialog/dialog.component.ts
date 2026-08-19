import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrl: './dialog.component.css',
  animations: [
    trigger('dialogAnimation', [
      state('void', style({
        opacity: 0,
        transform: 'translateY(-50px)'
      })),
      state('*', style({
        opacity: 1,
        transform: 'translateY(0)'
      })),
      transition('void => *', [
        animate('0.2s ease-in')
      ]),
      transition('* => void', [
        animate('0.2s ease-out', style({
          opacity: 0,
          transform: 'translateY(-50px)'
        }))
      ])
    ])
  ]
})
export class DialogComponent {
  @Output() submitEvent = new EventEmitter<any>();
  @Output() closeEvent = new EventEmitter<void>();

  isDialogOpen: boolean = true;
  dialogForm: FormGroup;
  parentList: any[] = [];
  childList: any[] = [];
  selectedParentId: number | null = null;
  selectedSupportName !: string;
  selectedParentID!: number | null;

  constructor(private fb: FormBuilder, private httpSer: HttpServiceService,) {
    this.dialogForm = this.fb.group({
      selectedId: [''],
    });
    this.callParentValueAPI(0);
  }

  closeDialog() {
    this.isDialogOpen = false;
    this.closeEvent.emit();
  }

  save() {
    if (this.dialogForm.get('selectedId')?.value == '') {
      return alert('Please select module!')
    }
    this.isDialogOpen = false;
    this.closeEvent.emit();
    const data = { formData: this.dialogForm.value, selectedSupportName: this.selectedSupportName, selectedParentID: this.selectedParentID };
    this.submitEvent.emit(data);
  }

  callParentValueAPI(ID: number) {
    const apiUrl = '/SupportMaster/GetParentValue';
    let param = { ParentId: ID }
    this.httpSer.httpGet(apiUrl, param).subscribe(res => {
      if (ID == 0) {
        this.parentList = res;
      } else {
        this.childList = res;
      }
    })
  }

  onParentRadioSelection(parent: any) {
    this.selectedParentId = parent.supportId;
    this.selectedSupportName = parent.supportName;
    this.selectedParentID = parent.parentId;
    this.callParentValueAPI(parent.supportId);
  }

  onChildRadioSelection(child: any) {
    this.selectedSupportName = child.supportName;
    this.selectedParentID = child.parentId;
  }

}
