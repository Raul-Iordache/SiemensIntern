import { Component, OnInit, OnDestroy} from '@angular/core';
import { UtilsService } from './services/utils.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Quiz';
  quiz: any[] | null = null;
  questionsPerGroup: number = 10;
  // groups: string[] = ['MATEMATICA', 'SPORT', 'CHIMIE', 'CINEMA', 'FOTBAL'];
  groups: any[] = [{name: 'MATEMATICA', active: true}, {name: 'SPORT', active: true}, {name: 'CHIMIE', active: true}, {name: 'CINEMA', active: true}, {name: 'FOTBAL', active: true}]
  indexQuestion : number = null; 
  indexGroup : number = null;
  activeQuestion: any = null;
  finalized: boolean = false;


  constructor(private utils: UtilsService) { }

  ngOnInit() {
    // this.quizGroups = this.groups;
  }

  public startQuiz(){
    console.log('groups for quiz: ', this.groups);
    this.indexGroup = 0;
    this.quiz = this.utils.generateQuestions(this.activeGroups, this.questionsPerGroup);
    this.setNewQuestion();
  }

  private setNewQuestion(): void {

    this.indexQuestion = this.indexQuestion === null ? 0 : this.indexQuestion + 1;
    if (this.indexQuestion % this.questionsPerGroup === 0 && this.indexQuestion > 0){
      if (this.indexGroup < this.activeGroups.length - 1) {
        this.indexGroup++;
      } else {
        //terminat quizul
          this.quizEnd();
          return;
      }
    }

    const groupName = this.activeGroups[this.indexGroup].name;
    this.activeQuestion = this.utils.getRandomQuestion(groupName, this.quiz);

    console.log(`Intrebarea nr ${this.indexQuestion}: `, this.activeQuestion);
  }

  public nextQuestion() {
    this.setNewQuestion();
    
  }

  private quizEnd() {
    this.finalized = true;
    console.log(`Finish quiz: `, this.quiz);

  }

  public logQuiz() {
    console.log('Quiz status: ', this.quiz);
  }

  correctAnswers(groupName: string): number {
    const group: any = this.quiz.find((g) => g.group === groupName);
    const questions: any[] = group.questions;
    let oks: number = 0;
    questions.forEach((q) => {
      let userOption = q.userAnswear;
      const options: any[] = q.options;
      for (let i=0; i< options.length; i++) {
        const option = options[i];
        if(option.ok && i == userOption)  {
          oks++;
        }
      }

    });

    return oks;
  }

  public changeGroups(groupName: string, event: any) {
    const checked: boolean = event.target.checked;
    console.log(groupName, checked);
    const group = this.groups.find((g) => g.name === groupName);
    group.active = checked;
  }

  public cancelQuiz(){
    this.activeQuestion = null;
    this.quiz = null;
    this.indexQuestion = null;
    this.indexGroup = null;
    this.finalized = false;
  }

  public get activeGroups(): any[] {
    return this.groups.filter((g) => g.active === true);
  }


}

