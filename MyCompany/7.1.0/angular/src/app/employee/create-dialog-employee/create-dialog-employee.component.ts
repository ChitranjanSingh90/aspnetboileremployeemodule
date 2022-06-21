import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  // RoleServiceProxy,
  // RoleDto,
  // PermissionDto,
  // CreateRoleDto,
  // PermissionDtoListResultDto
  EmployeeServiceProxy,
  EmployeeDto,
  CreateEmployeeDto
} from '@shared/service-proxies/service-proxies';
import { forEach as _forEach, map as _map } from 'lodash-es';

@Component({
  templateUrl: './create-dialog-employee.component.html'
})
export class CreateDialogEmployeeComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  role = new EmployeeDto();
  checkedPermissionsMap: { [key: string]: boolean } = {};
  defaultPermissionCheckedStatus = true;

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    private _employeeServiceProxy: EmployeeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {

  }


  save(): void {
    debugger;
    this.saving = true;

    const role = new CreateEmployeeDto();
    role.init(this.role);

    this._employeeServiceProxy
      .create(role)
      .subscribe(
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
