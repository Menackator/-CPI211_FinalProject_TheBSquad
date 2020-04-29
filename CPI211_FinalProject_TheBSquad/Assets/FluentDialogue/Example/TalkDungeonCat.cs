using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class TalkDungeonCat : ConversationWithImage
{
    public Booleans boolean;

    public override FluentNode Create()
    {
        return
            Show() *
            If(() => boolean.CattomFight == true,
                SpeakLot("I'm glad you got'em dude. But when the cops come please leave me out of it.", "Sounds/textMeow", 10) *
                Options(
                    Option("Ok...") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.ButlerFight == true,
                SpeakLot("Yikes, you look haunted.", "Sounds/textMeow", 10) *
                Options(
                    Option("I am...") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.DungeonFight == true,
                SpeakLot("Look, I'm sorry about Katherine. I hope you find the murderer dude.", "Sounds/textMeow", 10) *
                Options(
                    Option("Thanks") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.FancyFight == true,
                SpeakLot("What do you want?", "Sounds/textMeow", 10) *
                Options
                (
                    Options
                    (
                        Option("Dungeon Cat, I see you’re up to your usual bad behavior.") *
                            SpeakLot("Well... look who it is, Mister holier than thou.  What do you need from me now?", "Sounds/textMeow", 10) *
                            Options
                            (
                                Option("I’m looking for clues on what happened to Katherine. We both know you never liked her.") *
                                    SpeakLot("I don’t fraternize with cops, man. We simply have different... moral standings.", "Sounds/textMeow", 10) *
                                        Options
                                        (
                                            Option("Exactly why you’re my lead suspect.") *
                                                SpeakLot("Look, man, me and Kat never got along. In fact, I pretty much hated her. But I’d never kill anyone dude. Lifelong pacifist.", "Sounds/textMeow", 20) *
                                                Options(
                                                    Option("pacifist hmm.") *
                                                        Do(() => boolean.DungeonFight = true) *
                                                        Do(() => boolean.FancyFight = false) *
                                                        SpeakLot("You know I’ve been down here rolling in my catnip all day Cattyboy. \n" +
                                                        "I haven’t even been upstairs much since I knew Katherine is allergic to the stuff.", "Sounds/textMeow", 20) *
                                                        Options(
                                                            Option("But who else would have such a compelling motive?") *
                                                                SpeakLot("Butler Cat came down here yesterday and took some of my catnip. " +
                                                                "Paid pretty well too.  Wouldn’t tell me what for though.  Maybe talk to him dude.", "Sounds/textMeow", 20) *
                                                                Options(
                                                                    Option("How could I not think of this before?! I must go talk to the Butler immediately!") *
                                                                        Hide() *
                                                                        End()
                                                                )
                                                        )
                                                )
                                        )

                            )
                    ) *
                    Option("Bye!") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.FancyHint == true,
                SpeakLot("Why are you down here? Go away!", "Sounds/textMeow", 5) *
                Options(
                    Option("Ok") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.CookFight == true,
                SpeakLot("Why are you down here? Go away!", "Sounds/textMeow", 5) *
                Options(
                    Option("Ok") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.PoisonHint == true,
                SpeakLot("Why are you down here? Go away!", "Sounds/textMeow", 5) *
                Options(
                    Option("Ok") *
                        Hide() *
                        End()
                )
            ) *
            If(() => boolean.Beginning == true,
                SpeakLot("Why are you down here? Go away!", "Sounds/textMeow", 5) *
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