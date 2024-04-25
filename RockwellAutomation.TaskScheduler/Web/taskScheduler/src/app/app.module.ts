import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule, JsonPipe } from '@angular/common';
import { TaskItemsModule } from './components/taskItems/taskItems.module';
import { ExecutionTaskItemsModule } from './components/executionTaskItems/executionTaskItems.module';
import { ExecutionTaskItemState } from './states/executionTaskItem.state';
import { TaskItemState } from './states/taskItem.state';
import { NgxsModule } from '@ngxs/store';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    NgxsModule.forRoot([TaskItemState,ExecutionTaskItemState]),
    ExecutionTaskItemsModule,
    TaskItemsModule
   
  ],
  providers: [
    { provide: JsonPipe },
    provideClientHydration()],
  bootstrap: [AppComponent]
})
export class AppModule { }
