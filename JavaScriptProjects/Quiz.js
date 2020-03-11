const readline = require('readline-sync'); //will use readline for reading console
const fs = require('fs');
const path = require('path');

function GetQuestionsN(){
    let fileN = 0;
    while(true){
        try {
            const stats = fs.statSync (path.resolve() + '/QuizQs/q' + (fileN +1) + '.txt');
            if(stats.isFile()){
                fileN++;
            }
        } catch{
            break;
        }
    }
    return fileN;
}

function ChooseQN(){
    let qN;
    do{
        qN = readline.question("How many question do u need? ") - 0;
        if(qN > fileN){
            console.log('There is not enought questions...');
        }
        if(qN < 1){
            console.log('Choose more!!!');
        }
    }while(qN > fileN || qN < 1);
    return qN;
}

function ChooseQuestions(qN = 0, qC = 0){//questions number in directory, and choosen questions
    let qlist = [];
    let y = 0;
    for(let i = 0; i < qC; i++){
        let wrongX;
        do{
            wrongX = false;
            y = Math.ceil(Math.random() * qN);
            for(let j = 0; j < i; j++){
                if(qlist[j] == y){
                    wrongX = true;
                }
            }
        }while(wrongX);
        qlist[i] = y;
    }
    return qlist;
}

let quiz = [];
function MakeQuiz(tickets){
    for(i in tickets){
        var array = fs.readFileSync(path.resolve() + '/QuizQs/q' + tickets[i] + '.txt').toString().split("\n");
        let qQuestion ={
            aText: "empty",
            rightAnswer: 0,
            answers: []
        }
        for(j in array) {
            if(j == 0){
                qQuestion.aText = array[j];
            }else if(j == 1){
                qQuestion.rightAnswer = array[j];
            }else{
                if(array[j] != '' && array[j] != ' '){
                    qQuestion.answers[(j-2)] = array[j];
                }
            }
        }
        quiz[i] = qQuestion;
    }
}

function Game(quiz){
    let userpoints = 0;
    for(i in quiz){
        console.log(quiz[i].aText);
        for(j in quiz[i].answers){
            console.log(quiz[i].answers[j]);
        }
        console.log("");
        let userAnswer = readline.question("Choose the number of right answer ") - 0;
        if(userAnswer == (quiz[i].rightAnswer - 0)){
            userpoints++;
        }
    }
    return userpoints;
}

let fileN = GetQuestionsN();
console.log("There are " + fileN + " question cards.");
let qC = ChooseQN();
let tickets = ChooseQuestions(fileN, qC);
//console.log("Prepare to answer this tikets " + tickets.toString());
MakeQuiz(tickets);
let points = Game(quiz);
console.log("U've got " + points + " points");