Welcome to the Puzzle Game

Illustration 1:

Step 1: Create a two dimensional button array Button[,] btnLights; Step 2: Assign Tabindex to every button step 3: Add all button in a grid to display responsively step 4: after clicking on a button identifying 4 adjacent buttons

Here I used button Tabindex for finding other adjacent buttons.

Firstly,

   I find two array index value from Tabindex 

   Y= remainder of Tabindex by array length; 
   => btnY = ((btn.TabIndex - 1) % GridSize);
   

   X= quotient of Tabindex by array length;
   =>btnX = (int)((btn.TabIndex - 1) / GridSize);
Now We have btnLights[X,Y]

Secondly,

Now I have to check X and Y is positive and inside the bound. if bound is true then adding and subtracting 1 to X and Y I can get 4 adjacent Button index

          // Toggle button left
        if (btnX > 0)
        {
            ToggleButtonColor(btnLights[(btnX - 1), btnY]);
        }
        // Toggle button right
        if (btnX < (GridSize - 1))
        {
            ToggleButtonColor(btnLights[(btnX + 1), btnY]);
        }
        // Toggle button Up
        if (btnY > 0)
        {
            ToggleButtonColor(btnLights[btnX, (btnY - 1)]);
        }
        // Toggle button Down
        if (btnY < (GridSize - 1))
        {
            ToggleButtonColor(btnLights[btnX, (btnY + 1)]);
        }
Now passing all 5 parameter to a function for changing light state ToggleButtonColor(btnLights[X,Y])

Illustration 2:

        In this illustration we will find buttons by their Tabindex or Index;

        Here LB = LeftButton Tabindex, RB = RightButton Tabindex, TB = TopButton Tabindex, DB = DownButton Tabindex;


        Let,  l = array length;
        i = Tabindex;
        LB = ((i / l) - 1) * l + (i % l);
        RB = ((i / l) + 1) * l + (i % l);
        Where LB and RB must be > 0 to < Tabindex;

        Let, x = (i - 1) % l;
        if x != 0
        then TB = (i - 1);
        y = (i + 1) % l;
        if y != 0
        then
        DB = (i + 1);
