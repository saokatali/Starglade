import { NgModule } from '@angular/core';
import { MatButtonModule} from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list'; 






@NgModule({
  declarations: [],
  imports: [
    MatButtonModule
  ],
  exports: [MatButtonModule, MatGridListModule]
})
export class StargladeMaterialModule { }
