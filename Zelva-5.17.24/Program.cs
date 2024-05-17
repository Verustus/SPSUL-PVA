using System;
class Zelva{      // █2588     ░2591

    static int smer;
    static int i;
    static int j;
    static char[,] pole;
    
    static void kresli(bool pen, int kolik){
        int a=0,b=0;
        switch(smer){
            case 0:
                a=-1;
                break;
            case 1:
                b=1;
                break;
            case 2:
                a=1;
                break;
            case 3:
                b=-1;
                break;
        }
        if(pen){
            do{
                pole[i,j]='\u2588';
                i+=a;
                j+=b;
                kolik--;
            }while(kolik>0);
        }else{
            a*=kolik;
            b*=kolik;
            i+=a;
            j+=b;
        }
    }
    
    static void otoc(bool pravo){
        if(pravo){
            smer=(smer==3)?0:++smer;
        }else{
            smer=(smer==0)?3:--smer;
        }
    }
    
    static void prazdne(int vel){
        pole=new char[vel,vel+vel/2];
        for(i=0;i<vel;i++){
            for(j=0;j<vel;j++){
                pole[i,j]='\u2591';
            }
        }
    }
    
    static void spirala(int vel){
        j=0;
        i=vel-1;
        smer=1;
        for(int k=(vel-1);k>-1;k--){
            kresli(true,k);
            otoc(false);
            kresli(false,1);
        }
    }

    static void ctverec(int vel){
        j=vel/2-1;//1;
        i=vel/2-1;//1;
        smer=1;
        for(int k=0;k<4;k++){
            kresli(true,2);
            otoc(true);
        }
    }

    static void uhlopricka(int vel){
        j=0;
        i=0;
        smer=1;
        bool P_L=true;
        for(int k=0;k<vel;k++){
            kresli(true,1);
            otoc(P_L);
            kresli(false,1);
            P_L=!P_L;
        }
    }
    
    static void kriz(int vel){
        j=0;
        i=vel/2;
        smer=1;
        kresli(true,vel);
        j=vel/2;
        i=0;
        smer=2;
        kresli(true,vel);        
    }

    static void schody(int vel){
        j=0;
        i=0;
        smer=1;
        bool P_L=true;
        for(int k=0;k<vel-1;k++){
            kresli(true,2);
            otoc(P_L);
            P_L=!P_L;
        }
    }

    static void vlajka(int vel){
	for(i=0;i<vel;i++){
            for(j=0;j<vel+vel/2;j++){
			if(i>=j&&i+j<=vel-1){
				pole[i,j]='\u2588';
			}else if(i<vel/2){
				pole[i,j]='\u2591';
			}else{
				pole[i,j]='\u2593';
			}
		}
	}
    }
    
    
  static void Main() {
        int vel;
        
        Console.Write("Zadej velikost");
        if (int.TryParse(Console.ReadLine(),out vel)) {
            for(i=0;i<vel;i++){
                for(j=0;j<vel+vel/2;j++) {
                        Console.Write($"{pole[i, j]}{pole[i, j]}");
                }
                Console.WriteLine();
            }
        } else {
            Console.WriteLine("Velikost musí byt 32 bitové celé číslo!! Zkus to znovu.");
            Main();
        }
    }
}