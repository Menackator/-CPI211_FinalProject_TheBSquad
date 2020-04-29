using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class TalkDiary : ConversationWithImage
{
    public override FluentNode Create()
    {
        return
            Show() *
            Write(0, "Its grandpa's diary! Should I read some of it?") *
                Pause(1) *
                Options(
                    Option("Read recent entry") *
                        Write(0,"Cattom came to visit again today. His behavior and attitude is starting to unnerve me...") *
                    Option("Done") *
                    Hide() *
                    End()
                );
    }

}