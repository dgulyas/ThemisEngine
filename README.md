This is a side project, made for my own fun. It has a lot of ugly corners.

# Themis Engine

Themis is the Greek goddess of justice, divine order, and law. A game engine defines the underlying order of the game.

## Paradigm

Themis assumes the game is made of multiple spaces, each made up of multiple controls. One of the spaces is active, with it's controls being drawn onscreen. Clicks are captured and controls will trigger actions if they are clicked on.

## Example Project
An example game using Themis can be found [Here](https://github.com/dgulyas/HoleGame).

## Usage
Eventually there'll be a nuget package, but for now, create an empty project in your solution. Copy the contents of this repo (excluding .git and .gitignore) into it.

Create a new class that inherits from BaseSpace and that implements ISpace. Create the controls that make up the space in the space's Initialize function. An instance of the class will need to be added to the engine with the engine's AddSpace function. The engine's Update and Draw functions will need to be called in the matching functions that should be at the top level of your game.
