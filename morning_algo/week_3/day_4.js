/*  This is an algorithm given as an interview question for a software dev position at 
    Google that a previous student showed me



              >___0___<                                            >___0___<
....___________|_____|______________________________________________|_____|______________________....
                  P                                                    P


Scientists at NASA have opened a portal to another dimension. In this dimension, the plane of existence
is just an infinitely long line. To take readings, the scientists have sent 2 robots through the portal.
The two robots parachute down, but the trip through the portal sent them to entirely different locations.
Physics is also weird in this dimension, so when they parachute down, they also land directly on top of their
parachutes.

The key problem is that both robots have the SAME program written to power them. Given the following functions,
what code can you write to guarantee that eventually, the two robots will meet each other. You are not STRICTLY limited
to these functions, so you can use additional variables, while loops, conditionals and such in combination with 
these functions.

**** Predefined functions, you do not need to write anything. These are just the methods available for use **** */
function moveLeft() {
    // This function takes one unit of time, and moves the robot to the left one unit of distance.
}

function moveRight() {
    // This function takes one unit of time, and moves the robot to the right one unit of distance.
}

function wait() {
    // This function involves no movement of the robot and takes one unit of time.
}

function parachuteCheck() {
    // This function returns a boolean based on whether or not the robot is currently situated on top of a parachute
    // Takes one unit of time
}

function robotCheck() {
    // This function returns a boolean based on whether or not the robot has met another robot
    // Takes one unit of time
}

// *******************************************************************************************************

function findOtherRobots(){
    // Your Code Here
    moveLeft();
    while (!parachuteCheck)
        moveLeft();
        wait();
    while(!robotCheck)
        moveLeft();
        moveLeft();
}