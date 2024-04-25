import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { provideClientHydration } from '@angular/platform-browser';
import { NgxsModule } from '@ngxs/store';
import { NgxsReduxDevtoolsPluginModule } from '@ngxs/devtools-plugin';
import { NgxsLoggerPluginModule } from '@ngxs/logger-plugin';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ExecutionTaskItemState } from '../../states/executionTaskItem.state';
import { ExecutionTaskItemsComponent } from './executionTaskItems.component';
import { ExecutionTaskItemsRoutingModule } from './executionTaskItems-routing.module';

@NgModule({
  declarations: [
    ExecutionTaskItemsComponent
  ],
  imports: [
    CommonModule,
    NgxsModule.forRoot([ExecutionTaskItemState]),
    NgxsReduxDevtoolsPluginModule.forRoot(),
    NgxsLoggerPluginModule.forRoot(),
    HttpClientModule,
    ReactiveFormsModule,
    ExecutionTaskItemsRoutingModule
  ],
  providers: [
    provideClientHydration()]
})
export class ExecutionTaskItemsModule { }
