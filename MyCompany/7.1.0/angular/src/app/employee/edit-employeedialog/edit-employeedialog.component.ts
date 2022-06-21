import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, includes as _includes, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {

  EmployeeServiceProxy,
  //  GetEmployeeForEditOutput,
  EmployeeDto,
   //  EmployeeEditDto,
     Employee

} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: './edit-employeedialog.component.html'
})
export class EditEmployeedialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  id: number;
 //role:any
  //  role = new EmployeeEditDto();

  role = new Employee();
  
 
  grantedPermissionNames: string[];


  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _employeeServiceProxy: EmployeeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._employeeServiceProxy
      .getEmployeeForEdit(this.id)
      .subscribe((result: Employee) => {
        debugger;
        this.role = result;

      });
  }



  isPermissionChecked(permissionName: string): boolean {
    return _includes(this.grantedPermissionNames, permissionName);
  }


  save(): void {
    this.saving = true;

    const role = new EmployeeDto();
    role.init(this.role);

    this._employeeServiceProxy.update(role).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
