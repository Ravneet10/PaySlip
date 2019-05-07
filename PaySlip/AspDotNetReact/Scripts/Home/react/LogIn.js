import React, { Fragment } from 'react';
import { Paper, withStyles, Grid, TextField, Button, FormControlLabel, Checkbox } from '@material-ui/core';
import PaySlip from './PaySlip';
import { Redirect, Route, Link, BrowserRouter as Router } from 'react-router-dom';

const styles = theme => ({
    margin: {
        margin: theme.spacing.unit * 2,
    },
    padding: {
        padding: theme.spacing.unit
    },
    
});

class LogIn extends React.Component {
    constructor(props) {
        super(props);
        state: {
            showPayslip:false
        }
    }
    openPaySlip = () => {

    }
    render() {
        const { classes } = this.props;
        const styleWidth = {
            width: "900px",
            margin: "80px",
            height: "150px"
        }
        
        const marginBottom = {
            margin: "20px"
        }
        return (
            <Paper style={styleWidth}>
                <div className={classes.margin}>
                    <Grid container alignItems="flex-end">
                      
                        <Grid item md={true} sm={true} xs={true}>
                            <TextField id="username" label="Username" type="email" fullWidth autoFocus required />
                        </Grid>
                    </Grid>
                    <Grid container  alignItems="flex-end">
                        
                        <Grid item md={true} sm={true} xs={true}>
                            <TextField id="password" label="Password" type="password" fullWidth required />
                        </Grid>
                    </Grid>

                    <Grid container justify="center" style={marginBottom}>
                        <Button variant="contained" color="primary" onClick={() => { <Link to='/PaySlip' /> }}>Login</Button>
                    </Grid>
                 
                    <Router>
                        <div>
                            <ul>

                                <li>
                                    <Link to="/LogIn">Users</Link>
                                </li>
                                <li>
                                    <Link to="/PaySlip">Contact</Link>
                                </li>
                            </ul>

                            <Route path="/LogIn" component={LogIn} />
                            <Route path="/PaySlip" component={PaySlip} />
                        </div>
                    </Router>
                </div>
            </Paper>
           
           
            
        );
    }
}

export default  withStyles(styles)(LogIn);