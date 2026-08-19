import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AssetModuleRoutingModule } from './asset-module-routing.module';
import { AssetMasterComponent } from './asset-master/asset-master.component';
import { ViewAssetsComponent } from './view-assets/view-assets.component';
import { ItSpareComponent } from './it-spare/it-spare.component';
// import { ItConsumableComponent } from './it-consumable/it-consumable.component';
import { ItAssetComponent } from './it-asset/it-asset.component';
import { CommonAssetComponent } from './common-asset/common-asset.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ServiceModuleModule } from 'app/service-module/service-module.module';
import { MatTabsModule } from '@angular/material/tabs';
import { CommonAssetHistoryComponent } from './common-asset-history/common-asset-history.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { SpareMasterComponent } from './spare-master/spare-master.component';
import { CommonApproverComponent } from './common-approver/common-approver.component';
import { ApprovalTabComponent } from './approval-tab/approval-tab.component';
import { AssetSidebarComponent } from './asset-sidebar/asset-sidebar.component';

@NgModule({
  declarations: [
    AssetMasterComponent,
    ViewAssetsComponent,
    ItSpareComponent,
    ItAssetComponent,
    CommonAssetComponent,
    CommonAssetHistoryComponent,
    SpareMasterComponent,
    CommonApproverComponent,
    ApprovalTabComponent,
    AssetSidebarComponent
  ],
  imports: [
    CommonModule,
    AssetModuleRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ServiceModuleModule,
    MatTabsModule,
    MatFormFieldModule,
    MatPaginator,
    MatPaginatorModule,
    MatSelectModule,
  ]
})
export class AssetModuleModule { }
