import { Component, OnInit } from '@angular/core';
import { RepositoryService } from './../../shared/services/repository.service';
import { Owner } from './../../_interfaces/owner.model';

import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { Router } from '@angular/router';

import { ConfirmationDialogService } from '../../shared/modals/confirmation-dialog/confirmation-dialog.service';


@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css'],
})
export class OwnerListComponent implements OnInit {
  public owners: Owner[];

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
    let apiAddress: string = 'api/owner';

    this.repository.getData(apiAddress).subscribe(
      (res) => {
        this.owners = res as Owner[];
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      }
    );
  };

  public getOwnerDetails = (id) => {
    const detailsUrl: string = `/owner/details/${id}`;
    this.router.navigate([detailsUrl]);
  };

  public redirectToUpdatePage = (id) => {
    const updateUrl: string = `/owner/update/${id}`;
    this.router.navigate([updateUrl]);
  };

  public redirectToDeletePage = (id) => {
    const deleteUrl: string = `/owner/delete/${id}`;
    this.router.navigate([deleteUrl]);
  };

  public openConfirmationDialog(id,name) {
    this.confirmationDialogService
      .confirm(
        'Please confirm..',
        `Do you really want to delete ${name}?`
      )
      .then((confirmed) => {
        if (confirmed) this.deleteOwner(id);
      })
      .catch(() =>
        alert(
          'User dismissed the dialog (e.g., by using ESC, clicking the cross icon, or clicking outside the dialog)'
        )
      );
  }

  private deleteOwner = (id) => {
    
    const deleteUrl: string = `api/owner/${id}`;
    this.repository.delete(deleteUrl).subscribe(
      (res) => {
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      }
    );
  };

  public redirectToOwnerList = () => {
    this.router.navigate(['/owner/list']);
  };
}
