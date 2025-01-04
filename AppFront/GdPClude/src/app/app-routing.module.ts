import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfissionaisComponent } from './profissionais/profissionais.component';

const routes: Routes = [
  {path: 'profissionais', component:ProfissionaisComponent},
  {path: '', redirectTo:'profissionais',pathMatch:'full'},
  {path: '**', redirectTo:'profissionais',pathMatch:'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
