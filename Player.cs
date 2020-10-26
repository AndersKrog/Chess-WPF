using System;


// bliver ikke rigtig brugt til noget pt.

namespace CHESSWPF
{
    class Player
    {

        

        // er denne spiller en robot?
        public bool Human { get; set; }
        
        // står spilleren skak, ved ikke om den hører til her
        public bool Check { get; set; }
        
        // spillerens farver
        public bool White { get; set; }
        // spillerens navn
        public string Name { get; set; }
    }
    class AI
    {
        /*
         *  Skal muligvis deles op i flere klasser.
         *  
         *  
         *  derefter skal der laves en liste over træk
         *  
         *  primær 1 Først skal der tjekkes efter skak, hvis det er tilfældig:
         *      skal kongen flyttes eller en brik der kan blokere eller slå den brik der stiller kongen skak
         * 
         *  primær 2. listen skal tjekke om AI'en kan slå nogen brikker, og hvor mange point de så har
         *  
         *  primær 3. listen skal også tjekke om modstanderen i næste tur kan slå nogen af AI'ens brikker
         *  
         *  Sekundær 1. listen skal tjekke om brikken der flyttes kan slås i næste tur.
         *  
         *  
			------
			stadier: aggresiv /defensiv
			
			måske afhængig af hvor langt man er i spillet og hvor mange brikker AI har slået i forhold til menneskespiller
			
			et spil kunne inddeles i faser afhængigt af antal træk, hvor langt tid der er spillet og hvilke brikker der er slået
		 
         *  -----------------------------------------------------------------------------------
         *  Tilfældighed:
         *  
         *  Grundlæggende:
         *  hvis flere træk har samme antal point, skal der vælge et tilfældigt
         *  
         *  Sværhedsgrad:
         *  Alt skal pares med en variabel, således at sværhedsgraden kan indstilles
         *  En mulighed er at der er en sandsynlighed for at en brik overses.
         *  
         *    
         *  -----------------------------------------------------------------------------------
         */
    }
}
