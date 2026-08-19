import { map } from 'rxjs';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value : any[], searchText: string) : any[] {
      if(!value || !searchText){
        return value;
      }
      // return value.filter((item: any) =>item.toLowerCase().includes(searchText.toLowerCase()))
       return value.filter(item => (item.employeeName.toLowerCase().includes(searchText.toLowerCase())) || item.employeeId.includes(searchText))
      // return value.filter(item => (String(item.projectName).toLowerCase().includes(searchText.toLowerCase().split(' ').join(''))) || String(item.projectOwner).includes(searchText))
  }

}
