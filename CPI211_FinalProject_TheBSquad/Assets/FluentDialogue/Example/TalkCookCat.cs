using Fluent;
using System.Collections;
using UnityEngine;

//has sounds and booleans

public class TalkCookCat : ConversationWithImage
{
    public Booleans boolean;

    public GameController Game;

    public override FluentNode Create()
    {

        return
            Show() *
            If(() => boolean.ButlerFight == true || boolean.CattomFight == true,
                SpeakLot("What more do you want? Get out of my kitchen!", "Sounds/textMeow", 1) *
                Options(
                    Option("Ok") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.DungeonFight == true,
                SpeakLot("What more do you want? Get out of my kitchen!", "Sounds/textMeow", 1) *
                Options(
                    Option("Ok") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.FancyFight == true,
                SpeakLot("What more do you want? Get out of my kitchen!", "Sounds/textMeow", 10) *
                Options(
                    Option("Ok") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.FancyHint == true,
                SpeakLot("What more do you want? Get out of my kitchen!", "Sounds/textMeow", 10) *
                Options(
                    Option("Ok") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.CookFight == true,
                SpeakLot("Fine, ya got me beat. \n " +
                "All I know is that I found a cigar in the kitchen that sure doesn't belong to me. \n " +
                "Maybe go check that out? But you can keep looking around here too if it'll help.", "Sounds/textMeow", 20) *
                Options(
                    Option("Ok, thanks.") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.PoisonHint == true,
                SpeakLot("I am the Chef!\n" +
                "What do you want?", "Sounds/textMeow", 10) *
                Options
                (
                    Options(
                        Option("You have to admit that the poisoning point all claws at you, Cook Cat.  You were the one who had the most time around the food and must have tampered with it!") *
                            SpeakLot("Now why would I ever do something like that? You know this job is good, pays well, feeds well.", "Sounds/textMeow", 19) *
                            SpeakLot("Why would I ever want to jeopardize my spot in this uppity lil castle? ", "Sounds/textMeow", 10) *
                            SpeakLot("I never had anything against your girlfriend anyways, and nothing was gonna change that.", "Sounds/textMeow", 17) *
                            Options(
                                Option("That...I'm still figuring out. \nBut so far all evidence points to you, and I won't stop until I find out why.") *
                                    SpeakLot("You talk a big game for someone so puny. Keep talking like that and you're gonna get a paw right to the nose.", "Sounds/textMeow", 20) *
                                        Options(
                                            Option("Bring it on!") *
                                                Hide() *
                                                Do(() => boolean.CookFight = true) *
                                                Do(() => Game.gameState = 2) *
                                                Do(() => boolean.PoisonHint = false) *
                                                End() *
                                            Option("Nope") *
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
            If(() => boolean.Beginning == true,
                SpeakLot("What kid? Gotta problem?", "Sounds/textMeow", 5) *
                Options(
                    Option("I guess not.") *    
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
            Write(0,text) *
            Sounds(soundResource, amount)
        );
    }
}


