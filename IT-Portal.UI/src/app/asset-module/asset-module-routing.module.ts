import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssetMasterComponent } from './asset-master/asset-master.component';
import { ViewAssetsComponent } from './view-assets/view-assets.component';
import { SpareMasterComponent } from './spare-master/spare-master.component';
import { ItAssetComponent } from './it-asset/it-asset.component';
import { ItSpareComponent } from './it-spare/it-spare.component';

const routes: Routes = [
  { path: 'assetmaster', component: AssetMasterComponent },
  { path: 'viewassets', component: ViewAssetsComponent },
  { path: 'itspare', component: ItSpareComponent },
  // { path: 'itconsumable', component: CommonAssetComponent },
  { path: 'itasset', component: ItAssetComponent },
  {path : 'sparemaster',  component : SpareMasterComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetModuleRoutingModule { }
