import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from '@shared/paged-listing-component-base';
import {
  EmployeeServiceProxy,
  EmployeeDto,
  EmployeeDtoPagedResultDto
} from '@shared/service-proxies/service-proxies';

import { CreateDialogEmployeeComponent } from './create-dialog-employee/create-dialog-employee.component';
import { EditEmployeedialogComponent } from './edit-employeedialog/edit-employeedialog.component';


class PagedEmployeeRequestDto extends PagedRequestDto {
  keyword: string;
}

@Component({
  templateUrl: './employee.component.html',
  animations: [appModuleAnimation()]
})
export class EmployeeComponent extends PagedListingComponentBase<EmployeeDto> {
  employees: EmployeeDto[] = [];
  keyword = '';

  constructor(
    injector: Injector,
    private _employeeServiceProxy: EmployeeServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

  list(
    request: PagedEmployeeRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    debugger;
    this._employeeServiceProxy
      .getAll(request.keyword, request.skipCount, request.maxResultCount)
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: EmployeeDtoPagedResultDto) => {
        debugger;
        this.employees = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  delete(role: EmployeeDto): void {
    abp.message.confirm(
      this.l('EmployeeDeleteWarningMessage', role.firstName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._employeeServiceProxy
            .delete(role.id)
            .pipe(
              finalize(() => {
                abp.notify.success(this.l('SuccessfullyDeleted'));
                this.refresh();
              })
            )
            .subscribe(() => { });
        }
      }
    );
  }

  createEmployee(): void {
    this.showCreateOrEditRoleDialog();
  }

  editRole(role: EmployeeDto): void {
    this.showCreateOrEditRoleDialog(role.id);
  }

  showCreateOrEditRoleDialog(id?: number): void {
    let createOrEditRoleDialog: BsModalRef;
    if (!id) {
      createOrEditRoleDialog = this._modalService.show(
        CreateDialogEmployeeComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditRoleDialog = this._modalService.show(
        EditEmployeedialogComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditRoleDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
