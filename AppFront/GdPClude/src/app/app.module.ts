import { NgModule , Component} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProfissionaisComponent } from './profissionais/profissionais.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NavComponent } from './nav/nav.component';

import { CollapseDirective, CollapseModule } from 'ngx-bootstrap/collapse';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsModalService, ModalModule } from 'ngx-bootstrap/modal'
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';

import { ProfissionalService } from './services/profissional.service';
import { ExcluirComponent } from 'src/shared/excluir/excluir.component';
import { CadastroComponent } from './cadastro/cadastro.component';



@NgModule({
  declarations: [	
    AppComponent,
    ProfissionaisComponent,
    NavComponent,
    ExcluirComponent,
      CadastroComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    CollapseModule,
    BsDropdownModule,
    ModalModule,
    ToastrModule.forRoot(
      {
        timeOut: 5000,
        positionClass: 'toast-bottom-right',
        preventDuplicates:true,
        progressBar: true,
      }),
  ],
  providers: [ProfissionalService,
              BsModalService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
