import { Component, OnInit, Input, HostListener, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { ColumnApi, GridOptions, GridApi } from 'ag-grid-community';
import { SharedService } from '../shared/services/shared.service';


@Component({
  selector: 'app-ag-grid',
  templateUrl: './ag-grid.component.html',
  styleUrls: ['./ag-grid.component.scss']
})
export class AgGridComponent implements OnInit {

  @Output() valueChange: EventEmitter<any> = new EventEmitter();
  @Input() data: any[];
  @Input() columnDefs: any[];
  @Input() hideColumns: any[];
  x: boolean = false;
  @HostListener('window:resize', ['$event'])
  onResize(event) {
    // this.resize(event);
  }
  api: GridApi;
  columnApi: ColumnApi;
  gridOptions: GridOptions;
  dir: string;
  overlayLoadingTemplate: string;
  loadingOverlayComponent: string;
  overlayNoRowsTemplate: string;
  isGridEmpty: boolean = true;
  columnDefaultState: any;
  showGrid: boolean = false;
  rowSelection: string = "multiple";
  constructor(
    private sharedService: SharedService) {
    this.gridOptions = <GridOptions>{};
    this.gridOptions.suppressColumnVirtualisation = true;
    this.overlayLoadingTemplate = '<span class="ag-overlay-loading-center">טוען...</span>';
    this.overlayNoRowsTemplate = '<span class="ag-overlay-loading-center">אין שורות להציג</span>';
  }

  ngOnInit() {
    this.sharedService.showAllColumnsSubject.subscribe(
      {
        next: () => {
          this.showAllColumns();
        }
      });
    this.sharedService.getDirection().subscribe(dir => {
      this.dir = dir;
      console.log(dir)
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    if (this.data) {
      setTimeout(() => {
        this.columnApi.autoSizeAllColumns();
        this.showGrid = true;
        this.x = true;
        //TODO- fix this value
      }, 0.0000000000000000000000000000000000001);
    }
  }

  onGridReady(params) {
    this.x = false;
    this.showGrid = false;
    this.api = params.api;
    this.columnApi = params.columnApi;
    //TODO-If the data changes, or the width of a column changes,
    // then you may require the grid to calculate the height
    // again by calling api.resetRowHeights().
    params.api.resetRowHeights();
    this.columnDefaultState = this.columnApi.getColumnState();
  }

  onColumnVisible(event) {
    let columns = this.columnApi.getAllColumns().filter(column => column.isVisible());
    if (columns.length == 0)
      this.isGridEmpty = false;
    else
      this.isGridEmpty = true;
    if (event.finished) {
      this.api.resetRowHeights();
    }
  }

  showAllColumns() {
    this.gridOptions.suppressColumnVirtualisation = true;
    this.isGridEmpty = true;
    this.columnApi.setColumnState(this.columnDefaultState);
    this.columnApi.setColumnsVisible(this.columnApi.getAllColumns(), true);
    setTimeout(() => {
      this.columnApi.autoSizeAllColumns();
      //TODO- fix this value
    }, 0.0000000000001);
  }

  onSelectionChanged() {
    this.valueChange.emit(this.api.getSelectedRows()); 
  }

}