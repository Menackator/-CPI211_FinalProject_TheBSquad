using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class TalkCigar : ConversationWithImage
{
    public Booleans boolean;

    public override FluentNode Create()
    {
        boolean.FancyHint = true;
        boolean.CookFight = false;

        return
            Show() *
            Write(0, "This looks like the kind of cigar Fancy Cat smokes! What is it doing in the kitchen? Maybe he is the culprit!") *
                Pause(1) *
                Options(
                    Option("->") *
                        Hide() *
                        End()
                );
    }

}