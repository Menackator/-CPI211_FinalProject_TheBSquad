using Fluent;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class TalkButlerCat : ConversationWithImage
{
    public Booleans boolean;
    public GameController Game;

    public override FluentNode Create()
    {
        return
            Show() *
            If(() => boolean.CattomFight == true,
                SpeakLot("I see you have solved the mystery.", "Sounds/sfx_butlerCatSpeak1", 5) *
                Options(
                        Option("Yes. And you are so fired.") *
                            Hide() *
                            End()
                )
            ) *
            If(() => boolean.ButlerFight == true,
                 SpeakLot("...ow", "Sounds/sfx_butlerCatHurt1", 1) *
                Options(
                    Option("You've lost, Butler. Tell me the truth and I'll spare you your life.") *
                        SpeakLot("... fine... It was Cattom... he knew your Grandfather wanted to cut him out of the will... he overheard him telling Katherine that the mansion would go to you instead...he killed her to shut her up and enlisted my help... " +
                            "I would have gotten a cut of the profits of selling this stupid mansion if it was for you ruining everything...", "Sounds/sfx_butlerCatSpeak1", 20) *
                        Options(
                            Option("Cattom... no... how could he betray me like this?") *
                                Pause(1) *
                                Hide() *
                                End()
                        )
                )
            ) *
            If(() => boolean.DungeonFight == true,
                SpeakLot("Hm?", "Sounds/sfx_butlerCatSpeak1", 1) *
                Options(
                    Option("Butler! Stop right there!") *
                        SpeakLot("Ah yes, Catthew, how may I help you today?", "Sounds/sfx_butlerCatSpeak1", 10) *
                        Options(
                            Option("I've finally put the pieces together. I know who killed Katherine. It all makes sense.") *
                                SpeakLot("And whose that? You surely mustnt mean me.", "Sounds/sfx_butlerCatSpeak1", 10) *
                                Options(
                                    Option("You see, it's not just the cook cat that would have had access to the food, but also you. ") *
                                        Options(
                                            Option("The catnip you purchased from Dungeon Cat wouldn't be a lethal dose to anyone else, but you would know" +
                                            "that Katherines allergy could turn deadly with enough of it digested.  ") *
                                                Options(
                                                    Option("And that note I found must have been your list of things to buy on your shopping trip for the dinner!!" +
                                                    " And the cigar must have been a red herring to get me off your trail.") *
                                                        SpeakLot("Haha! Well sir I guess the jig is up.  Except for one thing...how could I have been at the generator and there to make sure Kattherine ate the food? It could not have possibly been me!! I'll be leaving now. " +
                                                        " Your 'proof' is meaningless.", "Sounds/sfx_butlerCatSpeak1", 20) *
                                                        Options(
                                                            Option("Like hell you will!") *
                                                                Do(() => boolean.ButlerFight = true) *
                                                                Do(() => boolean.DungeonFight = false) *
                                                                Do(() => Game.gameState = 6) *
                                                                Hide() *
                                                                End()
                                                        )
                                                )
                                        )
                                )
                        ) *
                    Option("Nothing...") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.FancyFight == true,
                SpeakLot("Do you need anything, sir?", "Sounds/sfx_butlerCatSpeak1", 10) *
                Options(
                    Option("No thank you.") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.FancyHint == true,
                SpeakLot("Have you found the killer yet?", "Sounds/sfx_butlerCatSpeak1", 10) *
                Options(
                    Option("No, but I'm getting close...") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.CookFight == true,
                SpeakLot("So you fought the cook?", "Sounds/sfx_butlerCatSpeak1", 10) *
                Options(
                    Option("Yep") *
                        SpeakLot("And did you learn anything, sir?", "Sounds/sfx_butlerCatSpeak1", 10) *
                        Options(
                            Option("Not really...") *
                            SpeakLot("Perhaps you should wait for the real police to arrive?", "Sounds/sfx_butlerCatSpeak1", 10) *
                            Options(
                                Option("No! I'm going to investigate the kitchen!") *
                                    Hide() *
                                    End()
                            )
                        )
                )
            ) *
            If(() => boolean.PoisonHint == true,
                Options
                (
                    SpeakLot("Hello sir.", "Sounds/sfx_butlerCatSpeak1", 2) *
                    Option("Who are you again?") *
                        SpeakLot("I'm Butler Cat.", "Sounds/sfx_butlerCatSpeak1", 5) *
                        Options(
                            Option("How do you know Cattom?") *
                                SpeakLot("Your brother would come help out at the mansion often.", "Sounds/sfx_butlerCatSpeak1", 10) *

                            Option("Bye") *
                                Hide() *
                                End()
                        ) *
                     Option("Bye") *
                     Hide() *
                     End()
                 )
            ) *
            If(() => boolean.Beginning == true,
                SpeakLot("Hello sir. I hear you are trying to find Kathrine's killer, have you found any clues?", "Sounds/sfx_butlerCatSpeak1", 10) *
                Options
                (
                    Option("No, not yet") *
                        SpeakLot("Have you interviewed the cook? He was in charge of the meals.", "Sounds/sfx_butlerCatSpeak1", 10) *
                        Options
                        (
                            Option("Then he could have put in the poison!") *
                                SpeakLot("He would have the opportunity...", "Sounds/sfx_butlerCatSpeak1", 10) *
                                Options
                                (
                                    Do(() => boolean.PoisonHint = true) *
                                    Do(() => boolean.Beginning = false) *
                                    Option("I'll go talk to him right now!") *
                                        SpeakLot("Good luck sir.", "Sounds/sfx_butlerCatSpeak1", 3) *
                                        Pause(1) *
                                        Hide() *
                                        End()
                                ) *

                            Option("Why does that matter?") *
                                SpeakLot("He could have slipped the poison in her drink.", "Sounds/sfx_butlerCatSpeak1", 10) *

                            Option("Back") *
                                Back()
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
