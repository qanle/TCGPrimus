
import { Component, OnInit } from '@angular/core';
import { RepositoryService } from './../../shared/services/repository.service';

import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { Router } from '@angular/router';

import { ConfirmationDialogService } from '../../shared/modals/confirmation-dialog/confirmation-dialog.service';

import { WorkflowItem } from 'app/_interfaces/workflow-item.model';

@Component({
  selector: 'app-workflow-item-list',
  templateUrl: './workflow-item-list.component.html',
  styleUrls: ['./workflow-item-list.component.css'],
})
export class WorkflowItemListComponent implements OnInit {
  public workflowItems: WorkflowItem[];
  public errorMessage: string = '';
  constructor(
    private repository: RepositoryService,
    private errorHandler: ErrorHandlerService,
    private router: Router,
    private confirmationDialogService: ConfirmationDialogService
  ) {}

  ngOnInit(): void {
    this.getAllOwners();
  }

  public getAllOwners = () => {
    let apiAddress: string = 'api/workflowitem';
    this.repository.getData(apiAddress).subscribe(
      (res) => {
        this.workflowItems = res as WorkflowItem[];
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      }
    );
  };

  public activitySetting(id, activitySetting) {
    alert('show setting');
    console.log(activitySetting);
  }

  public Update(id) {
    alert('show update');
  }

  public confirmationDeleteWorkflowItem(id, name) {
    this.confirmationDialogService
      .confirm(
        'Please confirm delete..',
        `Do you really want to delete ${name}?`
      )
      .then((confirmed) => {
        if (confirmed) alert('confirmed');
      })
      .catch(() =>
        alert(
          'User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'
        )
      );
  }

  public redirectToList = () => {
    this.router.navigate(['/workflow/list']);
  };
}
