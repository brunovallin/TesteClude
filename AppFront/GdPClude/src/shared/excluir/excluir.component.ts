import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
  styleUrls: ['./excluir.component.scss']
})
export class ExcluirComponent implements OnInit {


    //@Input() modalExterna: BsModalService = any;
    modalRef? : BsModalRef;

    constructor(private modalService: BsModalService,
                private toastrService: ToastrService
    ) {
      //modalService = this.modalExterna;
     }

    ngOnInit() {
    }

    excluir(id:number): void {
      this.modalRef?.hide();


      this.toastrService.success("Profissional excluído com sucesso!", "Sucesso!");
    }

    decline(): void {
      this.modalRef?.hide();
    }
}
