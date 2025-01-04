import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { ProfissionalService } from '../services/profissional.service';
import { Profissional } from '../model/Profissional';
import { Observable } from 'rxjs';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-profissionais',
  templateUrl: './profissionais.component.html',
  styleUrls: ['./profissionais.component.scss'],
})
export class ProfissionaisComponent implements OnInit {

  modalRef? : BsModalRef;
  public profissionais: Profissional[] = [];
  public profissionaisfiltrados: Profissional[] = [];
  private _filtroLista: string = 'Todos';

  public get filtroLista(){
    return this._filtroLista;
  }

  public set filtroLista(value:string){
    this._filtroLista = value;
    this.profissionaisfiltrados = this.filtroLista === 'Todos' ? this.filtrarProfissionais(this.filtroLista):this.profissionais;
  }

  public filtrarProfissionais(filtrarPor: string): Profissional[]{
    filtrarPor = filtrarPor.toLowerCase();
    return this.profissionais.filter(
      (profissional:Profissional) => profissional.especialidade.nome.toLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private profissionalService:ProfissionalService,
                      private modalService: BsModalService,
                      private toatrService: ToastrService
  ) {
  }

  public ngOnInit(): void {
    this.getProfissionais();
  }

  public getProfissionais(): void {
    this.profissionalService.getProfissionais().subscribe(
      (_profissionais:Profissional[]) => this.profissionais = _profissionais,
      (error:any) => console.log(error),
    );
  }

  public openModal(template: TemplateRef<void>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }


}
