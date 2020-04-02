package com.company;
import java.util.Arrays;
import java.util.Random;
import java.util.Scanner;
import java.io.*;
import static java.lang.Integer.parseInt;

public class Main {

    public static void main(String[] args) {

	    Scanner scan = new Scanner(System.in);
	    int password = Integer.parseInt(FindPassword());
Game1();
	    System.out.println("Glad to see u, sir!");
        System.out.println("What's ur name?");
        String name = scan.nextLine();
        if(name.intern() == "Anton"){
            System.out.println("Master has come!");
        }
        else{
            System.out.println("Guest is here!");
        }

        Boolean authorization = false;
        do{
            System.out.println("Guess the password:");
            int pass = scan.nextInt();
            if(pass == password){
                authorization = true;
            }else{
                System.out.println("Try again, bro.");
            }
        }while(!authorization);
        System.out.println("It's ok!");
        System.out.println("Do u wanna play game?");
        scan.nextLine();
        String message = scan.nextLine();
        if(message.intern() == "y"|| message.intern() == "yes"){
            //1st ganme;
        }else{
            System.out.println("So, what the hell do u want???");
        }
    }

    public static String FindPassword(){
        char[] buffer = new char[1024];
        try(FileReader readpass = new FileReader("D:\\ProperEducation\\JavaProjects\\src\\com\\company\\Password.txt")){
            int c;
            while((c = readpass.read(buffer)) > -1){
                buffer = Arrays.copyOf(buffer, c);
            }
        }
        catch(IOException e){
            System.out.println(e.getMessage());
        }
        String pass = new String(buffer);

        return pass;
    }
    public static void Game1(){
        Random r = new Random();
        Scanner scan = new Scanner(System.in);

        int charNumber = 3 + r.nextInt(4);
        System.out.println("Guess the number with " + charNumber + " different numerals.");
        int[] mystNumber = new int[charNumber];
        for(int i = 0; i < charNumber; i++){
            boolean ok ;
            int v;
            do{
                ok = true;
                v = r.nextInt(10);
                for(int j = 0; j < mystNumber.length; j++){
                    if(v == mystNumber[j]){
                        ok = false;
                        break;
                    }
                }
            }while(!ok);

            mystNumber[i] = v;
        }

        System.out.println(Arrays.toString(mystNumber));
        String userNumber = scan.nextLine();
        int [] goals;
        int [] wrongPos;
        if(userNumber.length() != mystNumber.length){
            System.out.println("Try again with attention!");
        }else{
            for(int i = 0; i < userNumber.length(); i++){
                for(int j = 0; j < mystNumber.length; j++){

                }
            }
        }
    }
}
