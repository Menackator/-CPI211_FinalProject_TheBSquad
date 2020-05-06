using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class TalkCigar : ConversationWithImage
{
    public Booleans boolean;

    public override FluentNode Create()
    {     
        return
            If(() => boolean.FancyHint == true || boolean.CookFight == true,
                Show() *
                Write(0, "This looks like the kind of cigar Fancy Cat smokes! What is it doing in the kitchen? Maybe he is the culprit!") *
                Do(() => boolean.FancyHint = true) *
                Do(() => boolean.CookFight = false) *
                Pause(1) *
                Options(
                    Option("->") *
                        Hide() *
                        End()
                )
            );
    }

}