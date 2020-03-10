var readline = require('readline-sync'); //will use readline for reading console

const monster = {
    maxHealth: 10,
    name: "Bloody",
    moves: [
        {
            "name": "Clawed paw hit",
            "physicalDmg": 3, // физический урон
            "magicDmg": 0,    // магический урон
            "physicArmorPercents": 20, // физическая броня
            "magicArmorPercents": 20,  // магическая броня
            "cooldown": 0     // ходов на восстановление
        },
        {
            "name": "Fire breath",
            "physicalDmg": 0,
            "magicDmg": 4,
            "physicArmorPercents": 0,
            "magicArmorPercents": 0,
            "cooldown": 3
        },
        {
            "name": "Hit with giant tale",
            "physicalDmg": 2,
            "magicDmg": 0,
            "physicArmorPercents": 50,
            "magicArmorPercents": 0,
            "cooldown": 2
        },
    ]
}

let BattleMage = {
    Health: 10,
    name: "BattleMage",
    moves: [
        {
            "name": "Hit with battle staff",
            "physicalDmg": 2,
            "magicDmg": 0,
            "physicArmorPercents": 0,
            "magicArmorPercents": 50,
            "cooldown": 0
        },
        {
            "name": "Double shot",
            "physicalDmg": 4,
            "magicDmg": 0,
            "physicArmorPercents": 0,
            "magicArmorPercents": 0,
            "cooldown": 4
        },
        {
            "name": "Fireball",
            "physicalDmg": 0,
            "magicDmg": 5,
            "physicArmorPercents": 0,
            "magicArmorPercents": 0,
            "cooldown": 3
        },
        {
            "name": "Magic barrier",
            "physicalDmg": 0,
            "magicDmg": 0,
            "physicArmorPercents": 100,
            "magicArmorPercents": 100,
            "cooldown": 4
        },
    ]
}

function DifficultyLvL(){
    let difficulty = 0;
    do{
        difficulty = readline.question("Choose the difficulty lvl (1 to 3) ");
    }while(difficulty < 1 || difficulty > 3);
    if(difficulty == 1){
        BattleMage.maxHealth = 15;
    }
    if(difficulty == 2){
        BattleMage.maxHealth = 11;
    }
    if(difficulty == 3){
        BattleMage.maxHealth = 9;
    }
}

function MonsterAction(lastMonsterSkillUse){
    let actionN;
    do{
        actionN = Math.floor(Math.random()* 3);
    }while(actionN == 3 || lastMonsterSkillUse[actionN] < monster.moves[actionN].cooldown);

    return actionN;
}

function MageAction(lastMageSkillUse){
    let actionN;
    do{
        actionN = readline.question("What should Battle Mage to do? (choose 1 to 4).. ") - 1;
        if(actionN > 3 || actionN < 0){
            console.log("... u've got only 4 skills (1 to 4)!!!")
        }
        if(lastMageSkillUse[actionN] < BattleMage.moves[actionN].cooldown){
            console.log("This skill is still in cooldown...")
        }
    }while(actionN > 3 || actionN < 0 || lastMageSkillUse[actionN] < BattleMage.moves[actionN].cooldown);

    return actionN;
}

function CalculateDmgToMonster(x = 0, y = 0){
    let mDmg = BattleMage.moves[y].magicDmg/100 * (100 - monster.moves[x].magicArmorPercents);
    let pDmg = BattleMage.moves[y].physicalDmg/100 * (100 - monster.moves[x].physicArmorPercents);
    let dmg = mDmg + pDmg;
    return dmg;
}

function CalculateDmgToMage(x = 0, y = 0){
    let mDmg = monster.moves[x].magicDmg/100 * (100 - BattleMage.moves[y].magicArmorPercents);
    let pDmg = monster.moves[x].physicalDmg/100 * (100 - BattleMage.moves[y].physicArmorPercents);
    let dmg = mDmg + pDmg;
    return dmg;
}

function TheStory(){
    console.log("Somewhere in the forest Battle Mage meet an unbelievable fiend, also known as Bloody...");
    console.log("Bloody take a look at Mage and start the battle.");
}

function GameBattle(){
    let monsterHP = monster.maxHealth;
    let mageHP = BattleMage.maxHealth;
    let lastMonsterSkillUse = [5,5,5];
    let lastMageSkillUse = [5,5,5];
    var x;
    var y;
    endbattle = false;
    do{
        x = MonsterAction(lastMonsterSkillUse);
        lastMonsterSkillUse[x] = 0;
        lastMonsterSkillUse.forEach(skill => skill++);
        console.log("Bloody prepare to make " + monster.moves[x].name);
        y = MageAction(lastMageSkillUse);
        lastMageSkillUse[y] = 0;
        lastMageSkillUse.forEach(skill => skill++);
        console.log("And Battle Mage makes " + BattleMage.moves[y].name);
        monsterHP -= CalculateDmgToMonster(x, y);
        mageHP -= CalculateDmgToMage(x, y);
        if(mageHP > 0){
            console.log("Mage is still alive with " + mageHP + "hp");
            if(monsterHP > 0){
                console.log("Monster continue the battle with " + monsterHP + "hp");
            }else{
                console.log("Monster is defeated!!!");
                endbattle = true;
            }
        }else{
            console.log("U let the hero down...");
            endbattle = true;
        }
    }while(!endbattle);
}

DifficultyLvL();
TheStory();
GameBattle();