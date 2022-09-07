import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonService } from '../../services/person.service';
import { switchMap, take } from 'rxjs/operators';
import { of } from 'rxjs';
import { Person } from '../../interfaces/person';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
  styleUrls: ['./person-form.component.css']
})
export class PersonFormComponent implements OnInit {

  personModel: FormGroup = new FormGroup({
    id: new FormControl(0, Validators.required),
    username: new FormControl('', Validators.required),
    fullname: new FormControl(''),
    date: new FormControl(new Date().toISOString().split('T')[0]),
    active: new FormControl(true),
    country: new FormControl(''),
    role: new FormControl(''),
  });

  constructor(private personService: PersonService,
    private router: Router,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap((params) => {
        console.log(params.get('id'));
        let id = params.get('id') ?? '';
        if (!id) return of();
        return this.personService.getById(Number(id));
      }), take(1)).subscribe(response => {
        if (!response) return;
        let person: Person = {
          id: response.id,
          username: response.username,
          fullname: response.fullname,
          date: response.date.split('T')[0],
          active: response.active,
          country: response.country,
          role:response.role
        };
        this.personModel.setValue(person);
      });
  }

  save() {
    if (!this.personModel.valid) return;
    if (!this.personModel.value.id)
      this.personService.create(this.personModel.value).subscribe(
        response => {
          console.log(response);
          //TODO: mensagem
          if (response.success) {
            this.router.navigate(['']);
          }
        },
        error => {
          console.log(error)
          //TODO: mensagem
        }
      );
    else
      this.personService.update(this.personModel.value).subscribe(
        response => {
          console.log(response);
          //TODO: mensagem
          if (response.success) {
            this.router.navigate(['']);
          }
        },
        error => {
          console.log(error)
          //TODO: mensagem
        }
      );
  }

  cancel() {
    this.router.navigate(['']);
  }

}
