using UnityEngine;
using Fluent;
using System.Collections;


public class TalkCattom : ConversationWithImage
{
    public Booleans boolean;
    public GameController Game;

    public override FluentNode Create()
    {
        return
            Show() *
            If(() => boolean.CattomFight == true,
                SpeakLot("...ugh", "Sounds/sfx_cattomSpeak1", 1) *
                Options(
                    Option("I have defeated you Cattom. The police are already on their way. And I recorded everything. What kind of detective doesn't record their investigations?") *
                        SpeakLot("Rot in hell, Catthew.", "Sounds/sfx_cattomSpeak1", 5) *
                        Options(
                            Option("You first.") *
                            //game ends
                                Pause(1) *
                                Do(() => Game.gameState = 10) *
                                Hide() *
                                End()
                        )
                )
            ) *
            If(() => boolean.ButlerFight == true,
                SpeakLot("I see you have learned the truth...", "Sounds/sfx_cattomSpeak1", 10) *
                SpeakLot("It's actually pretty easy to betray someone when everything you thought was yours was going to get ripped away from you.", "Sounds/sfx_cattomSpeak1", 20) *
                SpeakLot(" It's not my fault you were Grandpa's favorite!", "Sounds/sfx_cattomSpeak1", 10) *
                Options(
                    Option("He loved you too. But you... you never cared about this family. I know that now.") *
                        SpeakLot("Yes, and you know too much you weasel.  Which means not only Katherine but now you must die!", "Sounds/sfx_cattomSpeak1", 10) *
                            Pause(1) *
                            Do(() => boolean.CattomFight = true) *
                            Do(() => boolean.ButlerFight = false) *
                            Do(() => Game.gameState = 8) *
                            Hide() *
                            End()
                )
            ) *
            If(() => boolean.DungeonFight == true,
                SpeakLot("Who could it be... perhaps you missed something?", "Sounds/sfx_cattomSpeak1", 10) *
                Options(
                    Option("Perhaps...") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.FancyFight == true,
                SpeakLot("So, it wasn't Fancy Cat either? It must be Dungeon Cat then.", "Sounds/sfx_cattomSpeak1", 10) *
                Options(
                    Option("I'm going to interview him now.") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.FancyHint == true,
                SpeakLot("What can I help with brother?", "Sounds/sfx_cattomSpeak1", 10) *
                Options(
                    Option("I think the killer may be Fancy Cat!") *
                        SpeakLot("Really? How terrible. It is true I'm not sure why he was invited. Maybe he came only to murder her...", "Sounds/sfx_cattomSpeak1", 10) *
                            Option("I'm going to confront him right now!") *
                                Hide() *
                                End()
                )
            ) *
            If(() => boolean.CookFight == true,
                Options
                (
                    SpeakLot("I heard you fought the cook. I'm glad you have found the culprit.", "Sounds/sfx_cattomSpeak1", 10) *
                    Option("Actually, I don't think it was the chef.") *
                        SpeakLot("What? Who else could it have been?", "Sounds/sfx_cattomSpeak1", 10) *
                        Options
                        (
                            Option("Fancy Cat?") *
                                SpeakLot("Are you sure? Wow, I mean, maybe...", "Sounds/sfx_cattomSpeak1", 10) *
                                Options
                                (
                                    Option("I'm going to look for evidence!") *
                                        Write("...") *
                                        Pause(1) *
                                        Hide() *
                                        End()
                                ) *

                            Option("Butler Cat?") *
                                SpeakLot("No, trust me, there's no way it could have been Butler Cat.", "Sounds/sfx_cattomSpeak1", 10) *

                            Option("I don't know yet.") *
                                Hide() *
                                End()
                        )
                )
            ) *
            If(() => boolean.PoisonHint == true,
                SpeakLot("Are you going to confront the chef about the poison?", "Sounds/sfx_cattomSpeak1", 10) *
                Options(
                    Option("Yes!") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.Beginning == true,
                SpeakLot("Hi, brother. I'm sorry about your girlfriend, have you found any clues?", "Sounds/sfx_cattomSpeak1", 10) *
                Options
                (
                    Option("No, not yet") *
                        SpeakLot("How about asking the cook? Wasn't he in charge of the meals?", "Sounds/sfx_cattomSpeak1", 10) *
                        Options
                        (
                            Option("Really! Then he could have put in the poison!") *
                                SpeakLot("Yes! And he also didn't like Kathrine very much...", "Sounds/sfx_cattomSpeak1", 10) *
                                Options
                                (
                                    Do(() => boolean.PoisonHint = true) *
                                    Do(() => boolean.Beginning = false) *
                                    Option("I didn't know that! I'll go talk to him right now!") *
                                        SpeakLot("Ok, be careful...", "Sounds/sfx_cattomSpeak1", 10) *
                                        Pause(1) *
                                        Hide() *
                                        End()
                                ) *

                            Option("Why does that matter?") *
                                SpeakLot("He could have put the poison in her drink!", "Sounds/sfx_cattomSpeak1", 10) *

                            Option("Back") *
                                Back()
                        ) *

                    Option("Yes! I think the butler is suspicous!") *
                        SpeakLot("What? No! The butler wouldn't hurt a fly.", "Sounds/sfx_cattomSpeak1", 10) *
                        Options
                        (
                            Option("Really? He always seems cold to me...") *
                                SpeakLot("He's just shy. Trust me.", "Sounds/sfx_cattomSpeak1", 10) *
                                Options
                                (
                                    Option("Ok...") *
                                        Pause(1) *
                                        Hide() *
                                        End()
                                ) *

                            Option("If you say so...") *
                                Hide() *
                                End()
                        ) *

                    Option("Bye") *
                        Hide() *
                        End()
                )
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