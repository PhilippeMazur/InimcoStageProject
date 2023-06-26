import { Component, OnInit } from '@angular/core';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit {

  constructor(public service: PersonService) {
    service.GetAll();
   }

  ngOnInit(): void {
  }

}
