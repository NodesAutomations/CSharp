### List Custom Commands
- Ref : https://www.keanw.com/2007/03/getting_the_lis.html
```csharp
[CommandMethod("ListCustomCommands")]
        static public void ListCommandsFromThisAssembly()
        {
            // Just get the commands for this assembly
            Assembly asm = Assembly.GetExecutingAssembly();

            StringCollection sc = new StringCollection();

            object[] objs = asm.GetCustomAttributes(typeof(CommandClassAttribute), true);

            Type[] tps;

            int numTypes = objs.Length;

            if (numTypes > 0)
            {
                tps = new Type[numTypes];

                for (int i = 0; i < numTypes; i++)
                {
                    CommandClassAttribute cca = objs[i] as CommandClassAttribute;

                    if (cca != null)
                    {
                        tps[i] = cca.Type;
                    }
                }
            }
            else
            {
                tps = asm.GetExportedTypes();
            }

            foreach (Type tp in tps)
            {
                MethodInfo[] meths = tp?.GetMethods() ?? new MethodInfo[0];

                foreach (MethodInfo meth in meths)
                {
                    objs = meth.GetCustomAttributes(typeof(CommandMethodAttribute), true);

                    foreach (object obj in objs)
                    {
                        CommandMethodAttribute attb = (CommandMethodAttribute)obj;

                        sc.Add(attb.GlobalName);
                    }
                }
            }

            string[] cmds = new string[sc.Count];

            sc.CopyTo(cmds, 0);

            foreach (string cmd in cmds)
            {
                ActiveUtil.Editor.WriteMessage(cmd + "\n");
            }
        }
```
