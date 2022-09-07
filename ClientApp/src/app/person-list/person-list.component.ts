import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import Swal from 'sweetalert2';
import { Person } from '../../interfaces/person';
import { PersonService } from '../../services/person.service';

@Component({
  selector: 'app-person-list',
  styleUrls: ['./person-list.component.css'],
  templateUrl: './person-list.component.html'
})
export class PersonListComponent {

  public persons: Person[] = [];
  filter = {
    id: null,
    username: '',
    fullname: '',
    date: null,
    active: null,
    country: '',
    role: ''
  };

  constructor(private personService: PersonService,
    private router: Router) {
    this.personService.get(this.filter).pipe(take(1)).subscribe(result => {
      this.persons = result;
    }, error => console.error(error));
  }

  search() {
    this.personService.get(this.filter).pipe(take(1)).subscribe(result => {
      this.persons = result;
    }, error => console.error(error));
  }

  addRecordClick() {
    this.router.navigate(['form-person']);
  }

  editClick(id: string) {
    this.router.navigate([`form-person`, { id }]);
  }

  deleteClick(id: string) {
    Swal.fire({
      title: 'Tem certeza?',
      text: "Não será possível reverter a ação!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Sim, excluir!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.personService.delete(Number(id)).subscribe(response => {
          if (response.success)
            Swal.fire(
              'Excluido!',
              'O registro foi excluído.',
              'success'
            )
          else
            Swal.fire(
              'Erro!',
              response.message,
              'error'
            )
          this.personService.get().pipe(take(1)).subscribe(result => {
            this.persons = result;
          }, error => console.error(error));
        })
      }
    })
  }
}

