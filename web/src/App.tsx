import { Button, Card, CardContent, Grid, TextareaAutosize } from '@mui/material'
import Add from "@mui/icons-material/Add";
import { useState } from 'react'

import './App.css'
import { OpenAPI, RunResponse, ScriptService } from './services';

// Set the base URL for the service.
OpenAPI.BASE = 'http://localhost:5000';

// This is the default script
const defaultScript = `let msg = "Hello " + ctx.firstName + "!"; 
let client = new http();
res.resultLength = client.GetResponseLength("http://www.google.com");
res.message = msg;`;

function App() {
  const [ctx, setCtx] = useState('{ "firstName": "Charles", "email": "chen.charles.c@gmail.com" }');
  const [scriptlet, setScriptlet] = useState(defaultScript);
  const [result, setResult] = useState('');

  async function runScript() {
    console.log(ctx);
    console.log(scriptlet);

    const result: RunResponse = await ScriptService.runScript({
      requestBody: {
        ctx: ctx,
        script: scriptlet
      }
    });

    console.log(result);

    setResult(JSON.stringify(result));
  }

  return (
    <Grid container spacing={3}>
      <Grid item sm={0} md={1} lg={2}>

      </Grid>
      <Grid item sm={12} md={10} lg={8}>
        <Card
          sx={{ mx: 1, my: 4 }}
          variant="outlined">
          <CardContent>
            Ctx (JSON):
            <TextareaAutosize
              aria-label="Ctx"
              minRows={5}
              style={{ width: "100%" }}
              onChange={ (e) => setCtx(e.target.value) }
              value={ctx}/>
          </CardContent>
          <CardContent>
            Script:

            <TextareaAutosize
              aria-label="Script"
              minRows={5}
              style={{ width: "100%" }}
              onChange={ (e) => setScriptlet(e.target.value) }
              value={scriptlet} />
            <Button
              variant="outlined"
              size="small"
              startIcon={<Add />}
              onClick={async () => await runScript()}>
              Execute
            </Button>
          </CardContent>
          <CardContent>
            Result:
            <TextareaAutosize
              aria-label="Result"
              minRows={5}
              style={{ width: "100%" }}
              value={result} />
          </CardContent>
        </Card>
      </Grid>
      <Grid item sm={0} md={1} lg={2}>

      </Grid>
    </Grid>
  )
}

export default App
