using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class TalkEmpty : ConversationWithImage
{
    public Booleans boolean;

    public override FluentNode Create()
    {
        return
            If(() => boolean.FancyHint == true && boolean.CookFight == true,
                Show() *
                Write(0, "You shouldn't see this") *
                Options(
                    Option("->") *
                        Hide() *
                        End()
                )
            );
    }

}
