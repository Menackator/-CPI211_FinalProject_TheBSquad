using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

//has sounds and booleans

public class TalkFancyCat : ConversationWithImage
{
    public Booleans boolean;
    public GameController Game;

    public override FluentNode Create()
    {
        return
            Show() *
            If(() => boolean.ButlerFight == true,
                SpeakLot("You've avenged Katherine, good job.", "Sounds/textMeow", 10) *
                Options(
                    Option("Thank you") *       
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.ButlerFight == true,
                SpeakLot("I see you've found answers... ", "Sounds/textMeow", 10) *
                Options(
                    Option("Yea...") *
                        SpeakLot("Aren't you happy? You solved the mystery. You are going to avenge Katherine.", "Sounds/textMeow", 10) *
                        Options(
                            Option("You're right.") *
                                Hide() *
                                End() *
                            Option("I was hoping for a happier ending...") *
                                Hide() *
                                End()
                        )
                )
            ) *
            If(() => boolean.DungeonFight == true,
                SpeakLot("I hope this mess gets cleaned up soon.", "Sounds/textMeow", 10) *
                Options(
                    Option("I'm on it.") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.FancyFight == true,
                SpeakLot("You need to stop simply pointing paws at anyone suspicous.", "Sounds/textMeow", 10) *
                Options(
                    Option("I know...") *
                        SpeakLot("I heard strange noises coming from downstairs last night. " +
                                  "It could have been the generator, it’s been acting up, but I also know Dungeon Cat likes to lurk down there doing whatever he does. " +
                                  "And he might actually have a motive to commit such a dastardly crime.", "Sounds/textMeow", 20) *
                        Options(
                            Option("Thank you for the hint.") *
                            Hide() *
                            End()
                        )
                )
            ) *
            If(() => boolean.FancyHint == true,
                SpeakLot("Do you need something?", "Sounds/textMeow", 5) *
                Options
                (
                    Options
                    (
                        Option("Fancy Cat, it seems a rather damning cigar was found near the scene of the crime. Would you happen to know whose it is?") *
                            SpeakLot("Well I do declare that is my cigar, but alas, I know not how it came to be near the scene of the...accident.", "Sounds/textMeow", 19) *
                            Options
                            (
                                Option("Accident is doubtful, sir. And until I gather more evidence, you’re now my lead suspect.") *
                                    SpeakLot("How dare you jeopardize my good name with such foolishness! Apologize at once or be prepared to die at my paw.", "Sounds/textMeow", 20) *
                                        Options
                                        (
                                            Do(() => boolean.FancyFight = true) *
                                            Do(() => boolean.FancyHint = false) *
                                            Option("Well sir, if it means getting closer to the truth I’ll fight even you.") *
                                                Do(() => Game.gameState = 4) *
                                                Hide() *
                                                End() *
                                            Option("We must not be irrational… I just need to get closer to the truth. Is there anything you’ve seen?") *
                                                SpeakLot("Well...I don’t know if it can help, but I heard strange noises coming from downstairs last night. " +
                                                    "It could have been the generator, it’s been acting up, but I also know Dungeon Cat likes to lurk down there doing whatever he does. " +
                                                    "And he might actually have a motive to commit such a dastardly crime.", "Sounds/textMeow", 20) *
                                                Do(() => Game.gameState = 5) *
                                                Pause(1) *
                                                Hide() *
                                                End()
                                        )

                            )
                    ) *
                    Option("Bye!") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.CookFight == true,
                SpeakLot("I heard you fought the chef... how plebian...","Sounds/textMeow",10) *
                Options(
                    Option("...") *
                        Hide() *
                        End() *
                    Option("Rude.") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.PoisonHint == true,
                SpeakLot("What a tragedy... murder really does ruin a fine dinner.", "Sounds/textMeow", 5) *
                Options(
                    Option("Please be more concerned with the murder than the food.") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.Beginning == true,
                SpeakLot("What do you want? Shouldn't you talk to your brother?", "Sounds/textMeow", 5) *
                Options(
                    Option("Ok") *
                        Hide() *
                        End()
                )
            );
    }

    FluentNode Speak(string text, string soundResource)
    {
        return Parallel
            (
                Write(text) *
                Sound(soundResource)
            );
    }

    FluentNode Sounds(string soundResource, int amount)
    {
        if (amount < 4)
        {
            return Parallel(
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource)
            );
        }
        else if (amount < 7)
        {
            print("found 7");
            return SequentialNode(
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource)
            );
        }
        else if (amount < 11)
        {
            print("found 11");
            return SequentialNode(
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource)
            );
        }
        else if (amount < 21)
        {
            print("found 21");
            return SequentialNode(
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource) *
                Sound(soundResource)
            );
        }
        else
        {
            return (
                Sound(soundResource)
            );
        }
    }

    FluentNode SpeakLot(string text, string soundResource, int amount)
    {
        return Parallel(
            Write(text) *
            Sounds(soundResource, amount)
        );
    }
}

