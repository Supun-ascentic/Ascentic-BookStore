import * as React from 'react';
import { RouteComponentProps, withRouter, Link } from 'react-router-dom';
import axios from 'axios';

import 'antd/dist/antd.css';
import { FormComponentProps } from "antd/lib/form";
import { Form, Input, Button,Select,Icon} from 'antd';


const { Option } = Select;
const InputGroup = Input.Group;

const dataSource = ['Burns Bay Road', 'Downing Street', 'Wall Street'];

export interface IValues {
    [key: string]: any;
}
export interface IFormState {
    id: number;
    book: any;
    addedAuthors:any;
    addedCategories:any;
    values: IValues[];
    submitSuccess: boolean;
    loading: boolean;
    formLayout:any;
    categoriesList:any;
    authorsList:any;
    form: any;
    
}
type Props=RouteComponentProps<any> & FormComponentProps
class Login extends React.Component<Props, IFormState> {
    constructor(props: any) {
        super(props);
        this.state = {
            id: this.props.match.params.id,
            book: {},
            values: [],
            loading: false,
            submitSuccess: false,
            formLayout: 'horizontal',
            categoriesList:[],
            authorsList:[],
            addedAuthors:[],
            addedCategories:[],
            form: {}
            
        }
    }
    
    public componentDidMount(): void {
       
    }

    private Login = async (e: React.FormEvent<HTMLFormElement>): Promise<void> => {
        e.preventDefault();
        this.setState({ loading: true });
        let ValueData = this.state.values;
        

        let config = {
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'Access-Control-Allow-Origin': '*',
            }
        }

       console.log(this.state.values);
       axios.post(`https://localhost:5001/Account/Login`,this.state.values ,config).then(data => {
           console.log(data);
           localStorage.setItem('AccessToken', data.data);
            this.setState({ submitSuccess: true, loading: false })
            setTimeout(() => {
                this.props.history.push('/');
            }, 1500)
        }).catch(err=>{
              console.log(err.message)
          })
    }

    private setValues = (values: IValues) => {
        this.setState({ values: { ...this.state.values, ...values } });
    }
    private handleInputChanges = (e: React.FormEvent<HTMLInputElement>) => {
        e.preventDefault();
        this.setValues({ [e.currentTarget.id]: e.currentTarget.value })
    }



    public render() {
        const { formLayout } = this.state;

        const { getFieldDecorator, getFieldValue } = this.props.form; 
        
        const formItemLayout =
            formLayout === 'horizontal'
                ? {
                    labelCol: { span: 4 },
                    wrapperCol: { span: 14 },
                }
                : null;
            const buttonItemLayout =
            formLayout === 'horizontal'
                ? {
                    wrapperCol: { span: 14, offset: 4 },
                }
                : null;
        return (
            <div className="App">
                <h4>Login</h4>
               <Form onSubmit={this.Login} className="login-form">
                    <Form.Item>
                    {getFieldDecorator('email', {
                        rules: [{ required: true, message: 'Please input your username!' }],
                    })(
                        <Input
                        prefix={<Icon type="user" style={{ color: 'rgba(0,0,0,.25)' }} />}
                        placeholder="email"
                        onChange={this.handleInputChanges}/>,
                    )}
                    </Form.Item>
                    <Form.Item>
                    {getFieldDecorator('password', {
                        rules: [{ required: true, message: 'Please input your Password!' }],
                    })(
                        <Input
                        prefix={<Icon type="lock" style={{ color: 'rgba(0,0,0,.25)' }} />}
                        type="password"
                        placeholder="Password"
                        onChange={this.handleInputChanges}/>,
                    )}
                    </Form.Item>
                    <Form.Item>
                    <Button type="primary" htmlType="submit" className="login-form-button">
                        Log in
                    </Button>
                    Or <Link to={`/signup`} >register now!</Link>
                    </Form.Item>
                </Form>
            </div>
        )
    }
}
//export default withRouter(EditBook)
export default Form.create()(Login);