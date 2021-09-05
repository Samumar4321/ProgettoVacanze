#include <LiquidCrystal_I2C.h>
#include "pitches.h"
#define MAX 100
#define red 8
#define blu 9
#define white 10
#define btnRed 11
#define btnBlu 12
#define btnWhite 13
#define btnReset 2
#define MAXEL 3
#define MAXTIME 30000
#define buzzer 3
LiquidCrystal_I2C lcd(0x27, 16, 2);

int melodia[] = {
  NOTE_C4, NOTE_F4
};
int nNote=2;

int durataNote[] = {
  4, 4, 8, 8, 4, 4, 3, 8, 3, 8, 4, 8, 8, 8, 8, 4, 8, 8, 8, 8, 3
};

int Bottoni[MAXEL]={btnRed,btnBlu,btnWhite};
int cont=0;
int NLeds=MAXEL;
int Leds[MAXEL]={red,blu,white};
int ordine[MAX];



String LeggiFinoA(char term)
{
  String tmp;
  int i=0;
  while(true && i < 10000)
  {
    if(Serial.available())
    {
      char c=Serial.read();
      if(c==term)
        return tmp;
      else
      tmp += c;
    }
    i++;
  }
  return "";
}

void aspetta(int pin)
{
  while(digitalRead(pin) == LOW); //SE NON contiene nulla si può usare ";", aspetto fin quando il BTM1 non viene premuto
  while(digitalRead(pin) == HIGH);//fin quado non viene rilasciato
}

void dw(int Led,int Stato)
{
  digitalWrite(Led,Stato);
}

void vettoreRand()
{ 
   randomSeed(analogRead(A0));
   for (int i=0;i<MAX;i++)
  {
    ordine[i]=random(0,3);
  }
  
}
void inizioRoundLCD(int round, int punti)
{
   lcd.clear();
   lcd.print("Punti: " + String(punti));
   lcd.setCursor(0,1);
   lcd.print("Round: " + String(round)); 
}

bool timeController(long t1, long t2)
{
  if(t2-t1 > MAXTIME)
  {
    return true;
  }
  return false;
}

void startUpWait()
{
  lcd.clear();
  lcd.print("starting in: 5");
  delay(1000);
  lcd.clear();
  lcd.print("starting in: 4");
  delay(1000);
  lcd.clear();
  lcd.print("starting in: 3");
  delay(1000);
  lcd.clear();
  lcd.print("starting in: 2");
  delay(1000);
  lcd.clear();
  lcd.print("starting in: 1"); 
  delay(1000);
}
void setup()
{  Serial.begin(9600);
  for (int i=0;i<MAXEL;i++)
  {
    pinMode(Leds[i],OUTPUT);
    dw(Leds[i],LOW);
  }
 
  for (int i=0;i<MAXEL;i++)
  {
    pinMode(Bottoni[i],INPUT);

  }
  
  lcd.begin();
  lcd.backlight();
  lcd.cursor();
  lcd.home();
  pinMode(btnReset,INPUT);
  pinMode(buzzer,OUTPUT);
  //lcd.print("Hello");
  
  
  //lcd.begin(16,2);
  //lcd.print("Simon says");
  //password=LeggiFinoA(';');
  //*/
}

int numSeq=1;
int point=0;
int numBottone;
bool errore=false;
long startTime;
long actualTime;  
long gameStart;
long totalPlayTime;
String connec="";
void loop()
{
  startUpWait();
  /*
  if(connec=="")
  {
    lcd.clear();
    lcd.print("Loading...");
    delay(1000);
    connec = LeggiFinoA(';');
    //Serial.println(connec + "questo coso");
  }
  */
   vettoreRand();
   inizioRoundLCD(numSeq,point);
   if(numSeq == 1)
   {
    gameStart=millis();
   }
   for(int i=0;numSeq>i;i++)
   {
     dw(Leds[ordine[i]],HIGH);
     delay(500);
     dw(Leds[ordine[i]],LOW);
     delay(500); 
   }
  startTime = millis();

 
  for(int i=0;numSeq>i;i++)
  {    
  
    int PulsantePremuto=0;
    int pause=1;
    while(pause==1)
    {
      actualTime=millis();
     
      if(timeController(startTime,actualTime)==true)
      {
        pause=0;
        PulsantePremuto=-1;
      }
     
      if(digitalRead(Bottoni[0])==HIGH)
      {
        PulsantePremuto=0;
        while(Bottoni[0]==HIGH);
        pause=0;
              
        while(digitalRead(Bottoni[0])==HIGH);
      }
      else if(digitalRead(Bottoni[1])==HIGH)
      {
        PulsantePremuto=1;
        while(Bottoni[1]==HIGH);
        pause=0;
      
        while(digitalRead(Bottoni[1])==HIGH);

      }
      else if(digitalRead(Bottoni[2])==HIGH)
      {
        PulsantePremuto=2;
        while(Bottoni[2]==HIGH);
        pause=0;
       
        while(digitalRead(Bottoni[2])==HIGH);
      }
      
    }
  
    if(PulsantePremuto==ordine[i])
    {     
      errore = false;
      point++;
      lcd.setCursor(0,0);
      lcd.print("Punti: " + String(point));
      
    }
    else 
    {
      errore=true;
      //con break il for si blocca
      break;
    }
  }
  if(errore==true)
  {
    /*Serial.println("--------------------------------------");
    Serial.println("Hai totalizzato: " + String(point) +" punti");
    Serial.println("--------------------------------------");
    */
    totalPlayTime=millis() - gameStart;      
    lcd.clear();
    lcd.print(":( :( :( :(");
    lcd.setCursor(0,1);
    lcd.print("Punti: " + String(point));
    Serial.print(String(numSeq)+";" + String(point) + ";" + String(totalPlayTime) + "-");
    for(int i = 0; i < nNote; i++){
      int durata = 1500 / durataNote[i];
      tone(buzzer, melodia[i], durata);
      delay(durata * 1.3);
    }
    aspetta(btnReset);
    /*
    if(connec == "k")
    {
      //Serial.println("ci sono");
      String ghf="";
      while(ghf != "l")
      {
        //Serial.println("ciclo " + ghf);
        ghf = LeggiFinoA(';');
      }
    }
    //Serial.println("fuori");
    */
    point=0;
    numSeq=1;
  }
  else
  {
    numSeq++;
    
  }
 delay(100);

}
