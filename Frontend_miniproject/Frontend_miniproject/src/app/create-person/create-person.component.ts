import { Component, OnInit } from '@angular/core';
import { PersonService } from '../services/person.service';
import { Person } from '../entities/Person';
import { SocialSkills } from '../entities/SocialSkills';
import { SocialAccounts } from '../entities/SocialAccounts';

@Component({
  selector: 'app-create-person',
  templateUrl: './create-person.component.html',
  styleUrls: ['./create-person.component.css']
})
export class CreatePersonComponent implements OnInit {

  constructor(public service: PersonService) { }
  public skillContent: string[] = ["content1"];
  public accountContent: String[] = ["content1"];
  private skillCounter: number = 1;
  private accountCounter: number = 1;
  public person: Person = {
    firstname: "",
    lastname: "",
    socialSkills: [],
    socialAccounts: []
  }
  public amountVowels: string = "5";
  public amountConstenants: string = "";
  public fullname: string = "";
  public fullnameReversed: string = "";
  public personJSONFormat: string = "";
  public showError: boolean = true;

  ngOnInit(): void {
  }

  public addExtraSkill() {
    this.skillCounter++;
    this.skillContent.push("content" + this.skillCounter)
  }
  public deleteExtraSkill() {
    this.skillCounter--;
    this.skillContent.pop();
  }
  public addExtraAccount() {
    this.accountCounter++;
    this.accountContent.push("content" + this.accountCounter)
  }
  public deleteExtraAccount() {
    this.accountCounter--;
    this.accountContent.pop();
  }

  public createPerson() {
    const firstnameInput = document.querySelector('.firstname') as HTMLInputElement;
    const lastnameInput = document.querySelector('.lastname') as HTMLInputElement;

    this.person.firstname = firstnameInput.value;
    this.person.lastname = lastnameInput.value;

    const skillInputs = document.querySelectorAll('.skill') as NodeListOf<HTMLInputElement>;

    skillInputs.forEach(input => {
      const socialSkill: SocialSkills = {
        description: input.value
      }
      this.person.socialSkills.push(socialSkill)
    });

    const typeInputs = document.querySelectorAll('.type') as NodeListOf<HTMLInputElement>;
    const addressInputs = document.querySelectorAll('.address') as NodeListOf<HTMLInputElement>;

    for (let i = 0; i < typeInputs.length; i++) {
      const socialAccount: SocialAccounts = {
        type: typeInputs[i].value,
        address: addressInputs[i].value
      }

      this.person.socialAccounts.push(socialAccount)
    }

    const valid: boolean = this.validatePersonData(this.person)
    if (valid) {
      this.service.CreatePerson(this.person)

      this.fullname = this.person.firstname + " " + this.person.lastname;
      this.amountVowels = this.countVowels(this.fullname).toString();
      this.amountConstenants = this.countConsonants(this.fullname).toString();
      this.fullnameReversed = this.reverseString(this.fullname);
      this.personJSONFormat = JSON.stringify(this.person)

    } else {
      alert("Please make sure all fields are filled in.")
      this.person.socialSkills.splice(0, this.person.socialSkills.length)
      this.person.socialAccounts.splice(0, this.person.socialAccounts.length)
    }

  }

  validatePersonData(person: Person): boolean {
    if (
      person.firstname == '' ||
      person.lastname == '' ||
      !Array.isArray(person.socialSkills) ||
      !Array.isArray(person.socialAccounts)
    ) {
      return false;
    }

    for (const skill of person.socialSkills) {
      if (skill.description == '') {
        console.log(person.socialSkills)
        return false;
      }
    }

    for (const account of person.socialAccounts) {
      if (
        account.type == '' ||
        account.address == ''
      ) {
        return false;
      }
    }

    return true;
  }

  closeAlert() {
    this.showError = false;
  }



  countVowels(fullname: string) {
    const lowerStr = fullname.toLowerCase();

    const vowels = ['a', 'e', 'i', 'o', 'u'];

    let count = 0;

    for (let i = 0; i < lowerStr.length; i++) {
      if (vowels.includes(lowerStr[i])) {
        count++;
      }
    }

    return count;
  }

  countConsonants(fullname: string) {
    const lowerStr = fullname.toLowerCase();

    const vowels = ['a', 'e', 'i', 'o', 'u'];

    let count = 0;

    for (let i = 0; i < lowerStr.length; i++) {
      if (!vowels.includes(lowerStr[i]) && lowerStr[i].match(/[a-z]/i)) {
        count++;
      }
    }

    return count;
  }

  reverseString(fullname: string) {
    return fullname.split('').reverse().join('');
  }

}
