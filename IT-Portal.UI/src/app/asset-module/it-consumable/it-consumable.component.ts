import { Component, Input, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FormValidationService } from 'app/services/form-validation.service';
import { HttpServiceService } from 'shared/services/http-service.service';

@Component({
  selector: 'app-it-consumable',
  templateUrl: './it-consumable.component.html',
  styleUrls: ['./it-consumable.component.css','../assetmodule.css']
})
export class ItConsumableComponent {
  @Input() assetData: any;
  requestTypeList: any;
  assetId: any
  ITConsumableForm!: FormGroup;

  constructor(private fb: FormBuilder,
    private httpSer: HttpServiceService,
    public router: Router,
    private activeRoute: ActivatedRoute,
    public formValidationService: FormValidationService
  ) {
    this.activeRoute.queryParams.subscribe((m: any) => {
      this.assetId = m.assetId
    });
    this.formInit();
  }

  formInit() {
    this.ITConsumableForm = this.fb.group({
      requestType: ['']
    });
    if (!this.assetId) {
      this.getRequestType();
    }
  }

  getRequestType() {
    this.httpSer.httpGet('/SupportMaster/GetParentValue', { ParentId: 77 }).subscribe((res: any) => {
      this.requestTypeList = res;
      if (this.assetId) {
        this.ITConsumableForm.patchValue({ requestType: this.assetData.supportId })
      }
    })
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['srData']) {
      if (this.assetData != undefined) {
        this.patchFormValues(this.assetData)
      }
    }
  }

  patchFormValues(data: any) {
    if (this.assetData) {
      this.getRequestType();
    }

    this.ITConsumableForm.patchValue({
      // provideDescriptions: data.provideDescription || '',
    })

    if (this.assetData?.status?.trim() != 'Draft') {
      this.ITConsumableForm.disable();
    }
  }

  allFieldValues = {
    selectType: '',
  }

  changeRequestTypeValue() {
    this.ITConsumableForm.patchValue(this.allFieldValues);
  }

  clearAll() {
    this.ITConsumableForm.patchValue({ requestType: '' });
    this.ITConsumableForm.patchValue(this.allFieldValues);
    // this.selfOthersGuest.resetFields();
    // this.selfOthersGuest.getInputDatas();
  }

  Submit(status: any) {

  }
}
