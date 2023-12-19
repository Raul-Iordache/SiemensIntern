import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UtilsService {
  // groups: string[] = ['MATEMATICA', 'SPORT', 'CHIMIE', 'CINEMA', 'FOTBAL']

  

  constructor() { }

  public generateQuestions(groups: any[], questionsPerGroup: number): any[] {
    let index: number = 1;
    let quiz: any[] = [];
    

    groups.forEach(g => {

      // console.log('group name: ', g)
      const group_questions: any[] = [];
      for (var i = 0; i< questionsPerGroup; i++) {
        const question_options: any[] = [];
        let random = this.getRandomInt(0,3);
        for (var j = 0; j<4 ; j++){
          const option: any = {
            answear: `Raspunsul pentru intrebarea ${index}, OPTIUNEA ${j+1} (group: ${g.name})`,
            ok: j == random ? true : false
          };
          question_options.push(option);
        }

        const question: any = {
          id: index,
          userAnswear: null,
          question: `Intrebare ${index} ${g.name}`,
          options: question_options
        }

        group_questions.push(question);
        index++;
      }
      const new_group = {
        group: g.name,
        questions: group_questions
      };

      quiz.push(new_group);

    })

    console.log("Questions: ", quiz);
    return quiz;

  }

  public getRandomQuestion(groupName: string, quiz: any[]): any {

    const group: any = quiz.find((g) => g.group === groupName) || null;
    const questions: any[] = (group.questions as any[]).filter((q) => q.userAnswear === null) || null;
    if (questions === null) {
      return null;
    }
    const randomNum = this.getRandomInt(0, questions.length - 1)
    const question: any = questions[randomNum];
    return question;

  }

  private getRandomInt(min: number, max: number) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min) + min); // The maximum is exclusive and the minimum is inclusive
  }

}
