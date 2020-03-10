var readline = require('readline-sync'); //will use readline for reading console

function ImagineNumber(x){
    let imaginedNumber = [x];
    for(let i = 0; i < x; i++){
        let wrongNumber;
        do{
            wrongNumber = false;
            imaginedNumber[i] = Math.round(Math.random() * 9) - 0;
            for(let j = 0; j < i; j++){
                if(imaginedNumber[j] == imaginedNumber[i]){
                    wrongNumber = true;
                }
            }
        }while (wrongNumber==true);
    }
    return imaginedNumber;
}

function GetNumberFromUser(){
    let wronglength;
    let userNumber = 0;
    do{
        wronglength = false;
        userNumber = readline.question("So, guess the number! ");
        if(userNumber.length != imaginedNumber.length){
            console.log("Wrong Length");
            wronglength = true;
        }
    }while(wronglength == true);
    return userNumber;
}

function CalculateDifferences(imaginedNumber, userNumber){
    let fullmatch = false;
    let matches = 0;
    let matchedSymbols = '';
    let difLocMatches = 0;
    let difLocSymbols = '';
    for(let i = 0; i < imaginedNumber.length; i++){
        for(let j = 0; j < userNumber.length; j++){
            if(imaginedNumber[i] == userNumber[j]){
                if(i==j){
                    matches++;
                    matchedSymbols += imaginedNumber[i] + ", ";
                }else{
                    difLocMatches++;
                    difLocSymbols += imaginedNumber[i] + ", ";
                }
            }
        }
    }

    if( matches == imaginedNumber.length){
        console.log("Its a match!!!");
        fullmatch = true;
    }else{
        console.log("Try again");
        console.log("Matches "+ matches);
        console.log(matchedSymbols);
        console.log("Matches with wrong location "+ difLocMatches);
        console.log(difLocSymbols);
    }
    return fullmatch;
}

let symbolNumber = 0;
do{
    symbolNumber = readline.question("How long number can u guess? 3 to 6 symbols: ") - 0;
}while(symbolNumber < 3 || symbolNumber >6);

let tryNumber = 0;
do{
    tryNumber = readline.question("How many tries do u need to guess this number? ");
}while(tryNumber == 0);

let imaginedNumber = ImagineNumber(symbolNumber);
console.log(imaginedNumber.toString());//for tests

let userNumber;
let tryN = 0;
do{
    tryN++;
    if(tryN > tryNumber){
        console.log("Sorry, u loose...");
        break;
    }
    userNumber = GetNumberFromUser();
    console.log('This is the ' + tryN + ' try.');
}while(!CalculateDifferences(imaginedNumber, userNumber));