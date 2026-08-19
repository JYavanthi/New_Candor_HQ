import { Component, ViewEncapsulation, ElementRef, Renderer2, EventEmitter, Output } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { HttpServiceService } from 'shared/services/http-service.service';
import { firstValueFrom, forkJoin } from 'rxjs';
import { FormBuilder, FormGroup } from '@angular/forms';

interface Module {
  supportName: string;
  parentId: string;
  supportId: string;
}

interface Support {
  supportId: number;
  supportName: string;
  parentId: string;
  isActive: boolean;
  isVisible: boolean;
}

interface TreeNode {
  name: string;
  checked: boolean;
  expanded?: boolean;
  children?: TreeNode[];
  parentSupportId?: number;
  supportId?: number;
}

@Component({
  selector: 'app-user-config-treeview',
  templateUrl: './user-config-treeview.component.html',
  styleUrl: './user-config-treeview.component.css',
  encapsulation: ViewEncapsulation.ShadowDom,
  animations: [
    trigger('expandCollapse', [
      state('void', style({ height: '0', opacity: 0 })),
      state('*', style({ height: '*', opacity: 1 })),
      transition('void <=> *', [
        animate('300ms ease-in-out')
      ])
    ])
  ]
})
export class UserConfigTreeviewComponent {
  @Output() checkedItemsChanged = new EventEmitter<number[]>();
  treeData: TreeNode[] = [];
  userForm!:FormGroup
  constructor(private el: ElementRef, private renderer: Renderer2, private httpSer: HttpServiceService,
    public fb: FormBuilder) {
    const link = this.renderer.createElement('link');
    link.rel = 'stylesheet';
    link.href = 'https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css';
    this.renderer.appendChild(this.el.nativeElement.shadowRoot, link);
    this.getEachParentChild();
    
    this.userForm = this.fb.group({
    })
  }

  getServiceRequestListChildList: Support[] = [];

  async getEachParentChild() {
    await this.getServiceRequest(4);
    const requests = this.getServiceRequestList.map(module =>
      this.callParentValueAPI(parseInt(module.supportId))
    );
    forkJoin(requests).subscribe(results => {
      results.forEach(res => {
        if (Array.isArray(res)) {
          this.getServiceRequestListChildList.push(...res)
        }
      });
      this.generateTreeData();
    }, err => {
      console.error('Error fetching data:', err);
    });
  }
  callParentValueAPI(ID: number) {
    const apiUrl = '/SupportMaster/GetParentValue';
    return this.httpSer.httpGet(apiUrl, { ParentId: ID });
  }

  addControls(){
    // this.userForm.addControl(module.supportName, this.fb.control(false));
  }

  generateTreeData() {
    this.getServiceRequestList.forEach(module => {
      const children = this.getServiceRequestListChildList
        .filter(support => support.parentId === module.supportId)
        .map(support => ({
          name: support.supportName,
          checked: false,
          children: [],
          expanded: false,
          supportId: support.supportId
        }));

      this.treeData.push({
        name: module.supportName,
        checked: false,
        children: children,
        expanded: true,
        parentSupportId: parseInt(module.supportId)
      });
    });
  }

  onParentCheckChange(parentItem: TreeNode) {
    parentItem.children?.forEach(child => { child.checked = parentItem.checked })
    this.logCheckedItems();
  }

  onChildCheckChange(parentItem: TreeNode) {
    parentItem.checked = parentItem.children?.every(child => child.checked) ? true : false;
    this.logCheckedItems();
  }

  clearCheckedItems(items: TreeNode[]): void {
    items.forEach(item => {
      item.checked = false;
      if (item.children) {
        this.clearCheckedItems(item.children);
      }
    });
    this.logCheckedItems(false);
  }

  logCheckedItems(shouldLog: boolean = true) {
    const checkedItems = this.getCheckedItems(this.treeData);
    if (shouldLog) {
      this.checkedItemsChanged.emit(checkedItems);
    }
  }

  getCheckedItems(items: TreeNode[]): number[] {
    let checkedIDs: number[] = [];
    for (const item of items) {
      if (item.checked) {
        const supportId = item.supportId !== undefined ? item.supportId : item.parentSupportId;
        if (supportId !== undefined) {
          checkedIDs.push(supportId);
        }
      }
      if (item.children) {
        checkedIDs = checkedIDs.concat(this.getCheckedItems(item.children));
      }
    }
    return checkedIDs;
  }

  getServiceRequestList: Module[] = [];
  async getServiceRequest(ID: number) {
    const apiUrl = '/SupportMaster/GetParentValue';
    const response = await firstValueFrom(this.httpSer.httpGet(apiUrl, { ParentId: ID }));
    if (response) {
      this.getServiceRequestList = response;
    }
  }

  toggle(item: TreeNode) {
    item.expanded = !item.expanded;
  }

  getBackgroundColor(supportId?: number): string {
    switch (supportId) {
      case 8:
        return '#a17cef';
      case 36:
        return '#f3a358';
      case 71:
        return '#a6c978';
      case 53:
        return '#de5536';
      case 81:
        return '#f45518';
      case 56:
        return '#04b6e3';
      case 30:
        return '#4cd3d9';
      case 47:
        return '#31807a';
      case 50:
        return '#f78e9b';
      case 62:
        return '#62d4d3';
      case 65:
        return '#44b860';
      case 68:
        return '#83ab1d';
      case 74:
        return '#f5d364';
      case 77:
        return '#c8c6c7';
      case 83:
        return '#75c04b';
      case 88:
        return '#e17b9c';
      default:
        return '#cde9f7';
    }
  }

  getTextColor(supportId?: number): string {
    switch (supportId) {
      case 8:
        return '#ffffff';
      case 36:
        return '#000000';
      case 71:
        return '#000000';
      case 53:
        return '#ffffff';
      case 81:
        return '#ffffff';
      case 56:
        return '#ffffff';
      case 30:
        return '#ffffff';
      case 47:
        return '#ffffff';
      case 50:
        return '#000000';
      case 62:
        return '#000000';
      case 65:
        return '#ffffff';
      case 68:
        return '#ffffff';
      case 74:
        return '#000000';
      case 77:
        return '#000000';
      case 83:
        return '#ffffff';
      case 88:
        return '#ffffff';
      default:
        return '#000000';
    }
  }
}
